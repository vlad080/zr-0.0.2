using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure
{
    public class GameBootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;
        public LoadingCurtain Curtain;
        private IAssetProvider _assetProvider;

        private void Awake()
        {
            _game = new Game(this,  Curtain, _assetProvider);
            _game.StateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }
    }
}