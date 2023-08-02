using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;

        public GameFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }
        public void CreateCharacter()
        {
           // GameObject prefab = await _assetProvider.Load<GameObject>();
        }

        public void CreateHUD()
        {
        }

        public void CreateEnemy()
        { 
        }
    }
}