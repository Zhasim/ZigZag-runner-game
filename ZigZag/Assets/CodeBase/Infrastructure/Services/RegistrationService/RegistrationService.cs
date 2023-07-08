using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.RegistrationService
{
    public class RegistrationService : IRegistrationService
    {
        public List<IProgressReader> ProgressReaders { get; } = new ();
        public List<IProgressWriter> ProgressWriters { get; } = new();

        public void RegisterWatchers(GameObject gameObject)
        {
            foreach (IProgressReader progressReader in gameObject.GetComponentsInChildren<IProgressReader>())
                Register(progressReader);
        }

        public void Register(IProgressReader progressReader)
        {
            if (progressReader is IProgressWriter progressWriter)
                ProgressWriters.Add(progressWriter);
            ProgressReaders.Add(progressReader);
        }

        public void CleanUp()
        {
            ProgressReaders.Clear();
            ProgressWriters.Clear();
        }
    }
    
}