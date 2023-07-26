using System.Numerics;

namespace Code.Services.Input
{
    class StandaloneInputService : InputService
    {
        public override Vector3 LeftAxis
        {
            get
            {
                Vector3 axis = JoystickInputAxisLeft();
                if (axis == Vector3.Zero) axis = StandaloneAxisLeft();
                return axis;
            }
        }

       // public override Vector3 RightAxis
       // {
       //     get
       //     {
       //         Vector3 axis = JoystickInputAxisRight();
       //          if (axis == Vector3.Zero) axis = StandaloneAxisRight();
       //         return axis;
       //     }
       // }

        private static Vector3 StandaloneAxisLeft() =>
            new Vector3(UnityEngine.Input.GetAxis(HorizontalAxis),0 ,UnityEngine.Input.GetAxis(VerticalAxis));
        private static Vector3 StandaloneAxisRight() =>
            new Vector3(UnityEngine.Input.GetAxis(HorizontalAxisMouse),UnityEngine.Input.GetAxis(VerticalAxisMouse) ,0);
    }
}