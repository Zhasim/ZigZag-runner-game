using CodeBase.Infrastructure.StateMachine.Machine;

namespace CodeBase.Infrastructure
{
    public interface IGlobalStateMachineProvider
    {
        GlobalStateMachine GetStateMachine();
    }
}