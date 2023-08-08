using CodeBase.Infrastructure.StateMachines.GameStates;
using CodeBase.Infrastructure.StateMachines.Machines;
using CodeBase.Infrastructure.StateMachines.Provider;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Foundation
{
    public class Bootstrapper : MonoBehaviour
    {
        private IGlobalStateMachineProvider _stateMachineProvider;

        [Inject]
        private void Construct(IGlobalStateMachineProvider stateMachineProvider) => 
            _stateMachineProvider = stateMachineProvider;

        private void Start()
        {
            GlobalStateMachine stateMachine = _stateMachineProvider.GetStateMachine();
            stateMachine.Enter<BootstrapState>();
        }
    }
}
