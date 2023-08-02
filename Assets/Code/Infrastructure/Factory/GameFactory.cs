using System.Threading.Tasks;
using Code.Character;
using Code.Infrastructure.AssetManagement;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly IInputService _inputService;

        public GameFactory(IAssetProvider assetProvider, IInputService inputService)
        {
            _inputService = inputService;
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateCharacter()
        {
            var prefab = await _assetProvider.Load<GameObject>(AssetAddress.PlayerAddress);
             GameObject character = Object.Instantiate(prefab);
              character.GetComponent<CharacterMovement>().Construct(_inputService);
             return character;
        }

        public void CreateHUD()
        {
        }

        public void CreateEnemy()
        {
        }

        public async Task WarmUp() => 
            await _assetProvider.Load<GameObject>(AssetAddress.PlayerAddress);

        public void ClenUp()
        {
            _assetProvider.CleanUp();
        }
    }
}