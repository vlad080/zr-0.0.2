using System.Collections.Generic;
using System.Threading.Tasks;
using Code.Services.PersistentProgress.SaveLoad;
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
        List<ISavedProgressReader> ProgressReaders { get; }
        List<ISavedProgress> ProgressWriters { get; }
    }
}