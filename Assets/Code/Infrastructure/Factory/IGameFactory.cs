using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        public Task<GameObject> CreateCharacter();
        public Task<GameObject> CreateEnemy();
        public Task<GameObject> CreateHUD();
        void ClenUp();
        Task WarmUp();
    }
}