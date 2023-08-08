using CodeBase.Infrastructure.StateMachines.Machines;

namespace CodeBase.Infrastructure.StateMachines.Provider
{
    public interface IGlobalStateMachineProvider
    {
        GlobalStateMachine GetStateMachine();
    }
}