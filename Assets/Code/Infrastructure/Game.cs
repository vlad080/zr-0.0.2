using Code.Infrastructure.AssetManagement;

namespace Code.Infrastructure
{
    public class Game
    {
        // public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, IAssetProvider assetProvider)
        {
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, assetProvider);
        }
    }
}