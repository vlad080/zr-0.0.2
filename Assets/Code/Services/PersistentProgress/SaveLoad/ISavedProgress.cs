using Code.Data;

namespace Code.Services.PersistentProgress.SaveLoad
{
    public interface ISaveProgressReader
    {
        void LoadProgress(PlayerProgress progress);
    }

    public interface ISavedProgress : ISaveProgressReader
    {
        void UpdateProgress(PlayerProgress progress);
    }
}