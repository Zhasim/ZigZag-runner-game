using CodeBase.Infrastructure.Services.Input;
using CodeBase.Logic.TileGeneration.Creator;
using UnityEngine;
using Zenject;

namespace CodeBase.Logic.TileGeneration
{
    public class Game : MonoBehaviour
    {
        private ITileCreator _tileCreator;
        private IInputService _inputService;

        [Inject]
        public void Construct(ITileCreator tileCreator, IInputService inputService)
        {
            _tileCreator = tileCreator;
            _inputService = inputService;
        }

        private void Update()
        {
            if (_inputService.GetInputDown())
            {
                for (int i = 0; i < 3; i++) 
                    _tileCreator.CreateTile();
            }
        }
    }
}