using CodeBase.Infrastructure.Services.Input;
using CodeBase.Logic.TileGeneration.Creator;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration
{
    public class Game : MonoBehaviour
    {
        private ITileGenerator _tileGenerator;
        private IInputService _inputService;
        private bool _inputProcessed;

        [Inject]
        public void Construct(ITileGenerator tileGenerator, IInputService inputService)
        {
            _tileGenerator = tileGenerator;
            _inputService = inputService;
        }
        
        private void Update()
        {
            if (_inputService.GetInputDown() && !_inputProcessed)
            {
                _tileGenerator.HandlePlayerInput();
                _inputProcessed = true;
            }
            else if (!_inputService.GetInputDown())
            {
                _inputProcessed = false;
            }
        }
    }
}