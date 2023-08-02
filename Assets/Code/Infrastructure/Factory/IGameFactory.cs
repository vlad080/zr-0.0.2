using System.Threading.Tasks;

namespace Code.Infrastructure.Factory
{
    public interface IGameFactory
    {
        public void CreateCharacter();
        public void CreateHUD();
        void ClenUp();
        Task WarmUp();
    }
}