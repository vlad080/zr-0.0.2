using System.Numerics;

namespace Code.Services.Input
{
    class MobileInputService : InputService
    {
        public override Vector3 LeftAxis => JoystickInputAxisLeft();
       // public override Vector3 RightAxis => JoystickInputAxisRight();
    }
}