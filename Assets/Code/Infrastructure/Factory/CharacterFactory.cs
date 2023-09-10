using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Character;
using Code.Infrastructure.AssetManagement;
using Code.Services.Input;
using Code.Services.PersistentProgress.SaveLoad;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class CharacterFactory: ICharacterFactory
    {
        private readonly IInputService _inputService;
        private readonly IAssetProvider _assetProvider;
        public List<ISavedProgressReader> ProgressReaders { get; } = new List<ISavedProgressReader>();
        public List<ISavedProgress> ProgressWriters { get; } = new List<ISavedProgress>();

        public CharacterFactory(IInputService inputService, IAssetProvider assetProvider)
        {
            _inputService = inputService;
            _assetProvider = assetProvider;
        }

        public async Task<GameObject> CreateCharacter()
        {
            GameObject character = await Create(AssetAddress.PlayerAddress);
            character.GetComponent<CharacterMovement>().Construct(_inputService);
            RegisterProgressWatchers(character);
            return character;
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

        public async Task<GameObject> Create(string address)
        {
            GameObject prefab = await _assetProvider.Load<GameObject>(address);
            GameObject go = Object.Instantiate(prefab);
            return go;
        }
    }
}