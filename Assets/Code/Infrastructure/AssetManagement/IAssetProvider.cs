using System.Threading.Tasks;
using UnityEngine.AddressableAssets;

namespace Code.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        Task<T> Load<T>(AssetReference assetReference) where T : class;
        void CleanUp();
    }
}