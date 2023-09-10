using System.Threading.Tasks;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class EnemyFactory : IEnemyFactory
    {
        private readonly IBasicFactory _basicFactory;

        public EnemyFactory(IBasicFactory basicFactory)
        {
            _basicFactory = basicFactory;
        }

        public async Task<GameObject> CreateEnemy()
        {
            GameObject enemy = await _basicFactory.Create(AssetAddress.EnemyAddress);
            return enemy;
        }
    }

    public class UIFactory: IUIFactory
    {
        private readonly IBasicFactory _basicFactory;
        public UIFactory(IBasicFactory basicFactory)
        {
            _basicFactory = basicFactory;
        }

        public async Task<GameObject> CreateHUD()
        {
            GameObject hud = await _basicFactory.Create(AssetAddress.HUDAddress);
            return hud;
        }
    }

    public interface IUIFactory
    {
        public Task<GameObject> CreateHUD();
    }
}