using Code.Services.Input;
using UnityEngine;
using Zenject;

namespace Code.Infrastructure
{
    public class BootstrapInstaller : MonoInstaller
    {
        public GameObject JoystickService;

        public override void InstallBindings()
        {
            BindJoystickService();
            BindInputService();
        }

        private void BindJoystickService()
        {
            Container.Bind<IJoystick>().
                FromComponentInNewPrefab(JoystickService).
                AsSingle();
        }

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.
                    Bind<IInputService>().
                    To<StandaloneInputService>().AsSingle();
            else
                Container.Bind<IInputService>()
                    .To<MobileInputService>().AsSingle();
        }
    }
}