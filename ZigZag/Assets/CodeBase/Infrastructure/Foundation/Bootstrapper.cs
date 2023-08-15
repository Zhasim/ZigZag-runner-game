using System;
using CodeBase.Infrastructure.Services.Disposal;
using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Foundation
{
    public class Bootstrapper : MonoBehaviour
    {
        private IGlobalStateMachine _stateMachine;
        private IDisposer _disposer;

        [Inject]
        private void Construct(IGlobalStateMachine stateMachine, IDisposer disposer)
        {
            _stateMachine = stateMachine;
            _disposer = disposer;
        }

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        private void OnDestroy() => 
            _disposer.DisposeAll();
    }
}
