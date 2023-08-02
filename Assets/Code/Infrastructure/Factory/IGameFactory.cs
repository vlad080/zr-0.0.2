using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        public Task<GameObject> CreateCharacter();
        public void CreateHUD();
        void ClenUp();
        Task WarmUp();
    }
}