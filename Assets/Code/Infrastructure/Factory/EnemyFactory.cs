using System.Threading.Tasks;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IAssetProvider _assetProvider;

        public EnemyFactory(IAssetProvider assetProvider)
        {
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateEnemy()
        {
            GameObject enemy = await Create(AssetAddress.EnemyAddress);
            return enemy;
        }

        private async Task<GameObject> Create(string address)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(address);
            GameObject go = Object.Instantiate(prefab);
            return go;
        }

        private async Task<GameObject> Create(string address, Vector3 at)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(address);
            GameObject go = Object.Instantiate(prefab, at, Quaternion.identity);
            return go;
        }
    }
}