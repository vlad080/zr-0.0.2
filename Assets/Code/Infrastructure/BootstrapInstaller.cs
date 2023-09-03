﻿using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Infrastructure.States;
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
            BindFactoryService();
            BindPersistentProgressService();
            BindSaveLoadService();
        }

        private void BindSaveLoadService() =>
            Container.Bind<ISavedLoadService>().To<SavedLoadService>().AsSingle();

        private void BindPersistentProgressService() =>
            Container.Bind<IPersistentProgressService>().To<PersistentProgressService>().AsSingle();

        private void BindJoystickService() =>
            Container.Bind<IJoystick>().FromComponentInNewPrefab(JoystickService).AsSingle();

        private void BindAssetProviderService() =>
            Container.Bind<IAssetProvider>().To<AssetProvider>().AsSingle();

        private void BindFactoryService() =>
            Container.Bind<IGameFactory>().To<GameFactory>().AsSingle();

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