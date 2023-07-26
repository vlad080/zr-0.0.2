using System.Numerics;

namespace Code.Services.Input
{
    public interface IInputService : IServices
    {
        Vector3 LeftAxis { get; }
       // Vector3 RightAxis { get; }
    }
}