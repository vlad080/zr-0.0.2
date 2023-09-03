using Code.Data;

namespace Code.Infrastructure.States
{
    public interface ISavedLoadService
    {
        void SaveProgress();
        PlayerProgress LoadProgress();
    }
}