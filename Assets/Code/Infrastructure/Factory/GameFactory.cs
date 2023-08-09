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
            GameObject character = await Create(AssetAddress.PlayerAddress);
            character.GetComponent<CharacterMovement>().Construct(_inputService);
            return character;
        }

        public async Task<GameObject> CreateHUD() => 
            await Create(AssetAddress.HUDAddress);

        public async Task<GameObject> CreateEnemy()
        {
            GameObject enemy = await Create(AssetAddress.EnemyAddress);
            return enemy;
        }

        private async Task<GameObject> Create( string address)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(address);
            GameObject go = Object.Instantiate(prefab);
            return go;
        }

        public async Task WarmUp() =>
            await _assetProvider.Load<GameObject>(AssetAddress.PlayerAddress);

        public void ClenUp() => 
            _assetProvider.CleanUp();
    }
}