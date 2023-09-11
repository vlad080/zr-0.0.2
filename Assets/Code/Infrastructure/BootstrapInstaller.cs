using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Services.Input;
using Code.Services.PersistentProgress;
using Code.Services.PersistentProgress.SaveLoad;
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
            BindAssetProviderService();
            BindPersistentProgressService();
            BindSaveLoadService();
            BindAllFactoryService();
        }

        private void BindAllFactoryService()
        {
            Container.Bind<IBasicFactory>().To<BasicFactory>().AsSingle();
            Container.Bind<IEnemyFactory>().To<EnemyFactory>().AsSingle();
            Container.Bind<ICharacterFactory>().To<CharacterFactory>().AsSingle();
            Container.Bind<IUIFactory>().To<UIFactory>().AsSingle();
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();
        }

        private void BindSaveLoadService() =>
            Container.Bind<ISavedLoadService>().To<SavedLoadService>().AsSingle();

        private void BindPersistentProgressService() =>
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();

        private void BindJoystickService() =>
            Container.Bind<IJoystick>().FromComponentInNewPrefab(JoystickService).AsSingle();

        private void BindAssetProviderService() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindInputService()
        {
            if (Application.isEditor)
                Container.Bind<IInputService>().To<StandaloneInputService>().AsSingle();
            else
                Container.Bind<IInputService>()
                    .To<MobileInputService>().AsSingle();
        }
    }
}