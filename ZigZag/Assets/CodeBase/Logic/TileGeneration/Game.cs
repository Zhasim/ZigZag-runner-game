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

        [Inject]
        public void Construct(ITileGenerator tileGenerator, IInputService inputService)
        {
            _tileGenerator = tileGenerator;
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.GetInputDown())
            {
                for (int i = 0; i < 3; i++) 
                    _tileGenerator.CreateTile();
            }
        }
    }
}