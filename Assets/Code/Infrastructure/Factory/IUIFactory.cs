using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IUIFactory
    {
        public Task<GameObject> CreateHUD();
    }
}