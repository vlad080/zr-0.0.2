using System.Threading.Tasks;
using Code.Infrastructure.Factory;
using Code.Services.PersistentProgress;
using Code.Services.PersistentProgress.SaveLoad;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;
        private readonly IPersistentProgressService _progressService;
        private readonly IFactory _factory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader,
            LoadingCurtain curtain, IGameFactory gameFactory, IPersistentProgressService progressService, IFactory factory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _factory = factory;
            _curtain = curtain;
        }

        public async Task Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
            _gameFactory.ClenUp(); 
            
        }

        private async Task InitialWorld()
        {
            await _gameFactory.CreateCharacter();
            await _gameFactory.CreateEnemy();
            await _gameFactory.CreateHUD();
            await _factory.CharacterFactory.CreateCharacter();
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private async void OnLoaded()
        {
            await _gameFactory.WarmUp();
            await InitialWorld();
            InformProgressReaders();
            _stateMachine.Enter<GameLoopState>();
        }

        private void InformProgressReaders()
        {
            foreach (ISavedProgressReader progressReader in _gameFactory.ProgressReaders)
                progressReader.LoadProgress(_progressService.Progress);
        }
    }
}