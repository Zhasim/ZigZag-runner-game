using CodeBase.Infrastructure.StateMachine.Machine;

namespace CodeBase.Infrastructure.StateMachine.Provider
{
    public interface IGlobalStateMachineProvider
    {
        GlobalStateMachine GetStateMachine();
    }
}