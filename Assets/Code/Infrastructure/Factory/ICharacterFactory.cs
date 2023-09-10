using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface ICharacterFactory    {
        Task<GameObject> CreateCharacter();
    }
}