using System.Threading.Tasks;

namespace Code.Infrastructure
{
    public interface IState : IExitableState
    {
        void Enter();
    }

    public interface IPayloadState<TPayload> : IExitableState
    {
        Task Enter(TPayload payload);
    }

    public interface IExitableState
    {
        void Exit();
    }
}