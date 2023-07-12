using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pools
{
    public interface ILocalFactory<T> where T : MonoBehaviour
    {
        T Create();
    }
}