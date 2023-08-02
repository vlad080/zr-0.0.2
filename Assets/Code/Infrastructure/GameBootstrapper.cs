using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
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

        [Inject]
        public void Construct(IGameFactory gameFactory, IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
            _gameFactory = gameFactory;
        }

        private void Awake()
        {
            _game = new Game(this,  Curtain, _assetProvider,_gameFactory );
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}