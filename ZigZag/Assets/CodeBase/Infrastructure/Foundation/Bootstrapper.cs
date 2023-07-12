using CodeBase.Infrastructure.StateMachine.GameStates;
using CodeBase.Infrastructure.StateMachine.Machine;
using UnityEngine;
using Zenject;

namespace CodeBase.Infrastructure.Foundation
{
    public class Bootstrapper : MonoBehaviour
    {
        private IGlobalStateMachine _stateMachine;

        [Inject]
        private void Construct(IGlobalStateMachine stateMachine) => 
            _stateMachine = stateMachine;

        private void Start()
        {
            _stateMachine.Enter<BootstrapState>();
            DontDestroyOnLoad(this);
        }

        public class Factory : PlaceholderFactory<Bootstrapper>
        {
        }
    }
}
