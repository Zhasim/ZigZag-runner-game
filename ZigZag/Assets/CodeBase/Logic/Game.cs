using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Infrastructure.Services.Input;
using CodeBase.Logic.TileGeneration;
using Zenject;

namespace CodeBase.Logic
{
    public class Game : IInitializable, ITickable
    {
        // player 
        // tileGenerator
        
        // action (start)
        // action (pause)
        // action (end)
        
        // enmum states (start, pause, end) 

        private readonly ITileGenerator _tileGenerator;
        private readonly IInputService _inputService;
        private readonly ICoroutineRunner _coroutineRunner;

        public Game(ITileGenerator tileGenerator, IInputService inputService, ICoroutineRunner coroutineRunner)
        {
            _tileGenerator = tileGenerator;
            _inputService = inputService;
            _coroutineRunner = coroutineRunner;
        }
        
        public void Initialize()
        {
            _tileGenerator.Init();
            _tileGenerator.IsSpawning = true;
            _tileGenerator.StartSpawnRepeater();
        }

        public void Tick()
        {
            
        }
    }
}