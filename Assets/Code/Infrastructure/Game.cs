using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.States;
using Code.Services.PersistentProgress;
using Code.Services.PersistentProgress.SaveLoad;

namespace Code.Infrastructure
{
    public class Game
    {
        private readonly IGameFactory _gameFactory;

        // public static IInputService InputService;
        public readonly GameStateMachine StateMachine;

        public Game(ICoroutineRunner coroutineRunner, LoadingCurtain curtain, IAssetProvider assetProvider, 
            IGameFactory gameFactory, IPersistentProgressService persistentProgress, ISavedLoadService savedLoad)
        {
            _gameFactory = gameFactory;
            StateMachine = new GameStateMachine(new SceneLoader(coroutineRunner), 
                curtain, assetProvider,gameFactory, persistentProgress,savedLoad);
        }
    }
}