using System.Collections.Generic;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.Progress.Registration
{
    public interface IRegistrationService
    {
        List<IProgressReader> ProgressReaders { get; }
        List<IProgressWriter> ProgressWriters { get; }

        void CleanUp();
        void RegisterWatchers(GameObject gameObject);
    }
}