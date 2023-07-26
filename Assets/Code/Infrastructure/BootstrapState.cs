using Code.Services.Input;

namespace Code.Infrastructure
{
    public class BootstrapState : IState   
    {
        private const string CITY_SCENE = "City";
        private const string INITIAL_SCENE = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private IInputService _inputService;

        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader)
        {
            _stateMachine = stateMachine;
            _sceneLoader = sceneLoader;
        }

        public void Enter()
        {
            RegisterServices();
            _sceneLoader.Load(INITIAL_SCENE, onLoaded: EnterLoadLevel);
        }

        private void EnterLoadLevel() => 
            _stateMachine.Enter<LoadLevelState, string>(CITY_SCENE);

        private void RegisterServices()
        {
          //  _inputService = SetupInputService();
            
        }

        public void Exit()
        {
        }

      // private static IInputService SetupInputService()
      // {
      //     if (Application.isEditor)
      //         return new StandaloneInputService();
      //     else
      //         return new MobileInputService();
      // }
    }
}