using System.Collections.Generic;
using CodeBase.DI;
using CodeBase.Infrastructure.Services.Progress;
using CodeBase.Infrastructure.Services.Progress.Watchers;
using UnityEngine;

namespace CodeBase.Infrastructure.Services.RegistrationService
{
    public interface IRegistrationService : IService
    {
        List<IProgressReader> ProgressReaders { get; }
        List<IProgressWriter> ProgressWriters { get; }

        void CleanUp();
        void RegisterWatchers(GameObject gameObject);
        void Register(IProgressReader progressReader);
    }
}