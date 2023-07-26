using Code.Infrastructure.Factory;

namespace Code.Infrastructure
{
    public class LoadLevelState : IPayloadState<string>
    {
        
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private IGameFactory _gameFactory;

        public LoadLevelState(GameStateMachine stateMachine, SceneLoader sceneLoader,IGameFactory gameFactory )
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
            _gameFactory = gameFactory;
        }

        public void Enter(string sceneName) => 
            _sceneLoader.Load(sceneName);

        public void Exit()
        {
        }
    }
}