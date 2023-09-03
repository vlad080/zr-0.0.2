using Code.Data;
using Code.Infrastructure.States;
using UnityEngine;

namespace Code.Services.PersistentProgress.SaveLoad
{
    public class SavedLoadService : ISavedLoadService
    {
        private const string PROGRESS_KEY = "Progress";

        public void SaveProgress()
        {
        }

        public PlayerProgress LoadProgress() => 
            PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}