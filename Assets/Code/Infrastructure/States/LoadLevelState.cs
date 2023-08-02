using Code.Infrastructure.Factory;

namespace Code.Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private IGameFactory _gameFactory;
        private readonly LoadingCurtain _curtain;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader,
            LoadingCurtain curtain)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            
            _curtain = curtain;
        }

        public void Enter(string sceneName)
        {
            _curtain.Show();
            _sceneLoader.Load(sceneName,OnLoaded);
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