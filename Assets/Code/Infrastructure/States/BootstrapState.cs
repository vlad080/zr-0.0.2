using Code.Infrastructure.AssetManagement;

namespace Code.Infrastructure.States
{
    public class BootstrapState : IState   
    {
        private const string CITY_SCENE = "City";
        private const string INITIAL_SCENE = "Initial";
        private readonly GameStateMachine _stateMachine;
        private readonly SceneLoader _sceneLoader;
        private readonly IAssetProvider _assetProvider;
        
        public BootstrapState(GameStateMachine stateMachine, SceneLoader sceneLoader, IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
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
            _assetProvider.AddressablesInitialize();
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