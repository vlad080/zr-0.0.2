using System.Threading.Tasks;
using Code.Infrastructure.Factory;

namespace Code.Infrastructure.States
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly LoadingCurtain _curtain;
        private readonly IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader,
            LoadingCurtain curtain, IGameFactory gameFactory)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
            _curtain = curtain;
        }

        public async Task Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName, OnLoaded);
            await _gameFactory.WarmUp();
            await InitialWorld();
        }

        private async Task InitialWorld()
        {
            await _gameFactory.CreateCharacter();
            await _gameFactory.CreateEnemy();
            await _gameFactory.CreateHUD();
        }

        public void Exit()
        {
            _curtain.Hide();
        }

        private void OnLoaded()
        {
            _stateMachine.Enter<GameLoopState>();
        }
    }
}