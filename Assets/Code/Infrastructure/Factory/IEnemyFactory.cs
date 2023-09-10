using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IEnemyFactory
    {
        Task<GameObject> CreateEnemy();
    }
}