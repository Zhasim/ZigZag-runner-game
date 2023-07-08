using System.Collections;
using UnityEngine;

namespace CodeBase.Infrastructure.Foundation
{
    public interface ICoroutineRunner
    {
        Coroutine StartCoroutine(IEnumerator coroutine);
    }
}