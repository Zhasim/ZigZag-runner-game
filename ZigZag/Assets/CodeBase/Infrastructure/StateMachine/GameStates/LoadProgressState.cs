using CodeBase.Data;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.SaveLoad;
using CodeBase.Infrastructure.StateMachine.Machine;
using CodeBase.Infrastructure.StateMachine.States;
using CodeBase.StaticData;
using UnityEngine;
using UnityEngine.SceneManagement;
using Zenject;

namespace CodeBase.Infrastructure.StateMachine.GameStates
{
    public class LoadProgressState : IState
    {
        private readonly IGlobalStateMachine _stateMachine;
        private readonly IProgressService _progressService;
        private readonly ISaveLoadService _saveLoadService;

        public LoadProgressState(IGlobalStateMachine stateMachine, 
            IProgressService progressService,
            ISaveLoadService saveLoadService)
        {
            _stateMachine = stateMachine;
            _progressService = progressService;
            _saveLoadService = saveLoadService;
        }

        public void Enter()
        {
            Debug.Log($"State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}"); 
            
            LoadProgressOrInitNew();
            _stateMachine.Enter<LoadSceneState, string>(ScenesID.GAME_LOOP);
        }

        private void LoadProgressOrInitNew() => 
            _progressService.Progress = _saveLoadService.LoadProgress() ?? NewProgress();

        private OverallProgress NewProgress()
        {
            var progress = new OverallProgress();
            return progress;
        }

        public void Exit() => 
            Debug.Log($"Exited from State - {GetType().Name}, Scene - {SceneManager.GetActiveScene().name}");

        public class Factory : PlaceholderFactory<IGlobalStateMachine, LoadProgressState>
        {
        }
    }
}