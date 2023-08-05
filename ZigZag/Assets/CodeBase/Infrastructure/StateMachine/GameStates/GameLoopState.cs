using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.StateMachine.GameStates
{
    public class GameLoopState : IState
    {
        private readonly IGlobalStateMachine _globalStateMachine;

        public GameLoopState(IGlobalStateMachine globalStateMachine) => 
            _globalStateMachine = globalStateMachine;

        public void Enter()
        {
            Debug.Log($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");        

        }

        public void Exit()
        {
        }
        
    }
}