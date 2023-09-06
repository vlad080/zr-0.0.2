using Code.Data;

namespace Code.Services.PersistentProgress.SaveLoad
{
    public interface ISavedLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}