using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.States;
using Code.Services.PersistentProgress;
using Code.Services.PersistentProgress.SaveLoad;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        public LoadingCurtain Curtain;
        private IAssetProvider _assetProvider;
        private IGameFactory _gameFactory;
        private IPersistentProgressService _progressService;
        private ISavedLoadService _savedLoadService;

        [Inject]
        public void Construct(IGameFactory gameFactory, IAssetProvider assetProvider,
            IPersistentProgressService progressService, ISavedLoadService savedLoadService)
        {
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
            _progressService = progressService;
            _savedLoadService = savedLoadService;
        }

        private void Awake()
        {
            _game = new Game(this,  Curtain, _assetProvider,_gameFactory, _progressService,_savedLoadService );
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}