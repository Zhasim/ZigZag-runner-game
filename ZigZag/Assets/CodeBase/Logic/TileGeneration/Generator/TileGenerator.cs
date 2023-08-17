using System;
using System.Collections;
using CodeBase.Infrastructure.Foundation.CoroutineAccess;
using CodeBase.Logic.TileGeneration.Creator;
using UnityEngine;

namespace CodeBase.Logic.TileGeneration.Generator
{
    public class TileGenerator : ITileGenerator, IDisposable
    {
        private const float SpawnInterval = 0.2f;

        private Coroutine _generationRoutine;
        
        private readonly ITileCreator _tileCreator;
        private readonly ICoroutineRunner _coroutineRunner;

        public TileGenerator(ITileCreator tileCreator, ICoroutineRunner coroutineRunner)
        {
            _tileCreator = tileCreator;
            _coroutineRunner = coroutineRunner;
        }

        public void StartGeneration()
        {
            if (_generationRoutine == null)
            {
                _generationRoutine = _coroutineRunner.StartCoroutine(GenerateBlocks());;
            }
        }

        public void StopGeneration()
        {
            if (_generationRoutine != null)
            {
                _coroutineRunner.StopCoroutine(_generationRoutine);
                _generationRoutine = null;
            }
        }
        
        public void ResumeGeneration() => 
            _tileCreator.IsSpawning = true;

        public void PauseGeneration() => 
            _tileCreator.IsSpawning = false;
        
       
        public void Dispose()
        {
            StopGeneration();
            
            if (_generationRoutine != null)
            {
                _coroutineRunner.StopCoroutine(_generationRoutine);
                _generationRoutine = null;
            }
        }

        private IEnumerator GenerateBlocks()
        {
            while (_tileCreator.IsSpawning)
            {
                _tileCreator.CreateTile();
                yield return new WaitForSeconds(SpawnInterval);
            }
        }
    }
}