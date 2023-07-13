using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.Machine;
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
            DontDestroyOnLoad(this);
        }
    }
}
