using System.Threading.Tasks;
using Code.Infrastructure.AssetManagement;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
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
}