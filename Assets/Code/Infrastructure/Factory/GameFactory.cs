using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Character;
using Code.Infrastructure.AssetManagement;
using Code.Services.Input;
using Code.Services.PersistentProgress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class GameFactory : IGameFactory
    {
        private readonly IAssetProvider _assetProvider;
        private readonly ICharacterFactory _characterFactory;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public GameFactory(IAssetProvider assetProvider, ICharacterFactory characterFactory)
        {
            _characterFactory = characterFactory;
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateCharacter()
        {
            GameObject character = await _characterFactory.CreateCharacter();
            RegisterProgressWatchers(character);

            return character;
        }

        public async Task<GameObject> CreateHUD() =>
            await Create(AssetAddress.HUDAddress);

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

        public async Task WarmUp() =>
            await _assetProvider.Load<GameObject>(AssetAddress.PlayerAddress);

        public void ClenUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
            _assetProvider.CleanUp();
        }

        private void RegisterProgressWatchers(GameObject character)
        {
            foreach (ISavedProgressReader savedProgressReader in
                     character.GetComponentsInChildren<ISavedProgressReader>())
            {
                Register(savedProgressReader);
            }
        }

        private void Register(ISavedProgressReader progressReader)
        {
            if (progressReader is ISavedProgress progressWriter)
                ProgressWriters.Add(progressWriter);

            ProgressReaders.Add(progressReader);
        }
    }
}