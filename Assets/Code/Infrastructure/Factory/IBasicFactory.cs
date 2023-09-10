using System.Threading.Tasks;
using UnityEngine;

namespace Code.Infrastructure.Factory
{
    public interface IBasicFactory
    {
        public Task<GameObject> Create(string address);
        public Task<GameObject> Create(string address, Vector3 at);
    }
}