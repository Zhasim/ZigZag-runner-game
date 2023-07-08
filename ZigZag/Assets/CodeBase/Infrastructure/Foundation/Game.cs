using CodeBase.DI;
using CodeBase.Infrastructure.StateMachine;

namespace CodeBase.Infrastructure.Foundation
{
    public class Game
    {
        public readonly GlobalStateMachine stateMachine;

        public Game(ICoroutineRunner coroutineRunner)
        {
            stateMachine = new GlobalStateMachine(new SceneLoader(coroutineRunner), ServiceLocator.Container);
        }
    }
}