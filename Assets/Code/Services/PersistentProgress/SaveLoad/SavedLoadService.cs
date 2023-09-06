using Code.Data;
using Code.Infrastructure.Factory;
using UnityEngine;

namespace Code.Services.PersistentProgress.SaveLoad
{
    public class SavedLoadService : ISavedLoadService
    {
        private readonly IPersistentProgressService _progressService;
        private readonly IGameFactory _gameFactory;
        private const string PROGRESS_KEY = "Progress";

        public SavedLoadService(IPersistentProgressService progressService,IGameFactory gameFactory)
        {
            _progressService = progressService;
            _gameFactory = gameFactory;
        }

        public void SaveProgress()
        {
            foreach (ISavedProgress progressWriter in _gameFactory.ProgressWriters)
            {
                progressWriter.UpdateProgress(_progressService.Progress);
                PlayerPrefs.SetString(PROGRESS_KEY, _progressService.Progress.ToJson());
            }
        }

        public PlayerProgress LoadProgress() =>
            PlayerPrefs.GetString(PROGRESS_KEY)?.ToDeserialized<PlayerProgress>();
    }
}