using System.Numerics;
using Zenject;

namespace Code.Services.Input
{
    public abstract class InputService : IInputService
    {
        public IJoystick _joystickService;
        protected const string HorizontalAxis = "Horizontal";
        protected const string VerticalAxis = "Vertical";
        protected const string HorizontalAxisMouse = "Mouse X";
        protected const string VerticalAxisMouse = "Mouse Y";
        public abstract Vector3 LeftAxis { get; }
        //public abstract Vector3 RightAxis { get; }

        [Inject]
        public void Construct(IJoystick joystickService) => 
            _joystickService = joystickService;

        protected Vector3 JoystickInputAxisLeft() =>
            new Vector3(_joystickService.HorizontalAxis(), 0,_joystickService.VerticalAxis());
        
        
        
       // protected Vector3 JoystickInputAxisRight() =>
       //     new Vector3(StaticJoystick.Instance.GetHorizontalAxis(false), StaticJoystick.Instance.GetVerticalAxis(false),0);
    }
}