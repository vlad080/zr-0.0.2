using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine.AddressableAssets;
using UnityEngine.ResourceManagement.AsyncOperations;

namespace Code.Infrastructure.AssetManagement
{
    public class AssetProvider : IAssetProvider
    {
        private readonly Dictionary<string, AsyncOperationHandle> _completedCache =
            new Dictionary<string, AsyncOperationHandle>();
        private readonly Dictionary<string, List<AsyncOperationHandle>> _handles =
            new Dictionary<string, List<AsyncOperationHandle>>();

        
        
        public void AddressablesInitialize() => 
            Addressables.InitializeAsync();

        public async Task<T> Load<T>(string assetPath) where T : class
        {
            if (_completedCache.TryGetValue(assetPath, out AsyncOperationHandle competedHandle))
                return competedHandle.Result as T;

            AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetPath);
            handle.Completed += completeHandle =>
            {
                _completedCache[assetPath] = completeHandle;
            };
            AddHandle(handle, assetPath);

            return await handle.Task;
        }

        private void AddHandle<T>(AsyncOperationHandle<T> handle, string key) where T : class
        {
            if (!_handles.TryGetValue(key, out List<AsyncOperationHandle> resourceHandle))
            {
                resourceHandle = new List<AsyncOperationHandle>();
                _handles[key] = resourceHandle;
            }
            
            resourceHandle.Add(handle);
        }

        public void CleanUp()
        {
            foreach (List<AsyncOperationHandle> resourceHandles in _handles.Values)
            foreach (AsyncOperationHandle handle in resourceHandles)
                Addressables.Release(handle);
            
            _completedCache.Clear();
            _handles.Clear();
        }

        // public async Task<T> Load<T>(AssetReference assetReference) where T : class
      // {
      //     if (_completedCache.TryGetValue(assetReference.AssetGUID, out AsyncOperationHandle competedHandle))
      //     {
      //         return competedHandle.Result as T;
      //     }

      //     AsyncOperationHandle<T> handle = Addressables.LoadAssetAsync<T>(assetReference);
      //     string cacheKey = assetReference.AssetGUID;
      //     return await RunWithCacheOnComplete(handle, cacheKey);
      // }

      // private async Task<T> RunWithCacheOnComplete<T>(AsyncOperationHandle<T> handle, string cacheKey) where T : class
      // {
      //     handle.Completed += h => { _completedCache[cacheKey] = h; };

      //     AddHandle(handle, cacheKey);

      //     return await handle.Task;
      // }
    }
}