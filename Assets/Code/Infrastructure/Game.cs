using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;

namespace Code.Infrastructure
{
    public class Game
    {
        private readonly IGameFactory _gameFactory;

        // public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, IAssetProvider assetProvider, IGameFactory gameFactory)
        {
            _gameFactory = gameFactory;
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), curtain, assetProvider,gameFactory);
        }
    }
}