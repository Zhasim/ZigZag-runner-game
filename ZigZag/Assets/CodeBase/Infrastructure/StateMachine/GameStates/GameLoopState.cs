using CodeBase.Infrastructure.StateMachine.States;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CodeBase.Infrastructure.StateMachine.GameStates
{
    public class GameLoopState : IState
    {
        public void Enter()
        {
            Debug.Log($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");        

        }

        public void Exit()
        {
        }
    }
}