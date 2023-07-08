using CodeBase.Infrastructure.StateMachine.GameStates;
using UnityEngine;

namespace CodeBase.Infrastructure.Foundation
{
    public class Bootstrapper : MonoBehaviour, ICoroutineRunner
    {
        private Game _game;

        private void Awake()
        {
            _game = new Game(this);
            _game.stateMachine.Enter<BootsTrapState>();
            
            DontDestroyOnLoad(this);
        }
    }
}
