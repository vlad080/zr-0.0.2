﻿using System.Threading.Tasks;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        //Task<T> Load<T>(AssetReference assetReference) where T : class;
        Task<T> Load<T>(string assetPath)where T : class;
        void CleanUp();
        void AddressablesInitialize();
    }
}