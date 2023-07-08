using CodeBase.Data;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using CodeBase.Infrastructure.Services.RegistrationService;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.SaveLoad
{
    public class SaveLoadService : ISaveLoadService
    {
        private const string PROGRESS = "Progress";
        
        private readonly IProgressService _progressService;
        private readonly IRegistrationService _registrationService;

        public SaveLoadService(IProgressService progressService, IRegistrationService registrationService)
        {
            _progressService = progressService;
            _registrationService = registrationService;
        }

        public void SaveProgress()
        {
            foreach (IProgressWriter progressWriter in _registrationService.ProgressWriters)
                progressWriter.WriteProgress(_progressService.Progress);
            
            PlayerPrefs.SetString(PROGRESS, _progressService.Progress.ToJson());
        }

        public OverallProgress LoadProgress() => 
            PlayerPrefs.GetString(PROGRESS)?.ToDeserialized<OverallProgress>();
    }
}