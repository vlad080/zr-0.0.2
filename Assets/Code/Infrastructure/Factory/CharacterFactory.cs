﻿using System.Threading.Tasks;
using Code.Character;
using Code.Infrastructure.AssetManagement;
using Code.Services.Input;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public class CharacterFactory : ICharacterFactory
    {
        private readonly IInputService _inputService;
        private readonly IBasicFactory _basicFactory;

        public CharacterFactory(IInputService inputService, IBasicFactory basicFactory)
        {
            _inputService = inputService;
            _basicFactory = basicFactory;
        }

        public async Task<GameObject> CreateCharacter()
        {
           // GameObject character = await Create(AssetAddress.PlayerAddress);
           GameObject character = await _basicFactory.Create(AssetAddress.PlayerAddress);
            character.GetComponent<CharacterMovement>().Construct(_inputService);
            return character;
        }

       // public async Task<GameObject> Create(string address)
       // {
       //     GameObject prefab = await _assetProvider.Load<GameObject>(address);
       //     GameObject go = Object.Instantiate(prefab);
       //     return go;
       // }
       // private async Task<GameObject> Create(string address, Vector3 at)
       // {
       //     GameObject prefab = await _assetProvider.Load<GameObject>(address);
       //     GameObject go = Object.Instantiate(prefab, at, Quaternion.identity);
       //     return go;
       // }
    }
}