﻿using System;
using System.Collections.Generic;
using Code.Infrastructure.AssetManagement;
using Code.Infrastructure.Factory;
using Code.Services.PersistentProgress;
using Code.Services.PersistentProgress.SaveLoad;

namespace Code.Infrastructure.States
{
    public class GameStateMachine
    {
        private readonly Dictionary<Type, IExitableState> _states;
        private IExitableState _activeState;

        public GameStateMachine(SceneLoader sceneLoader, LoadingCurtain curtain, IAssetProvider assetProvider,
            IGameFactory gameFactory, IPersistentProgressService progressService, ISavedLoadService savedLoadService)
        {
            _states = new Dictionary<Type, IExitableState>
            {
                [typeof(BootstrapState)] = new BootstrapState(this, sceneLoader, assetProvider),
                [typeof(LoadLevelState)] = new LoadLevelState(this, sceneLoader, curtain, gameFactory,progressService),
                [typeof(LoadProgressState)] = new LoadProgressState(this, progressService,savedLoadService ),
                [typeof(GameLoopState)] = new GameLoopState(this),
            };
        }

        public void Enter<TState>() where TState : class, IState
        {
            IState state = ChangeState<TState>();
            state.Enter();
        }

        public void Enter<TState, TPayload>(TPayload payLoad) where TState : class, IPayloadState<TPayload>
        {
            TState state = ChangeState<TState>();
            state.Enter(payLoad);
        }

        private TState ChangeState<TState>() where TState : class, IExitableState
        {
            _activeState?.Exit();
            TState state = GetState<TState>();
            _activeState = state;
            return state;
        }

        private TState GetState<TState>() where TState : class, IExitableState =>
            _states[typeof(TState)] as TState;
    }
}