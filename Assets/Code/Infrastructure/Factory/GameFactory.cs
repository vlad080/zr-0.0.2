using System.Threading.Tasks;
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
          //   GameObject prefab = await _assetProvider.Load<GameObject>();
        }

        public void CreateHUD()
        {
        }

        public void CreateEnemy()
        {
        }

        public async Task WarmUp()
        {
            await _assetProvider.Load<GameObject>(AssetAddress.PlayerAddress);
        }

        public void ClenUp()
        {
            _assetProvider.CleanUp();
        }
    }
}