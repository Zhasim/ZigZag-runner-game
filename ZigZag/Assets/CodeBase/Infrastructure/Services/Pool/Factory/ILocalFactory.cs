using UnityEngine;

namespace CodeBase.Infrastructure.Services.Pool.Factory
{
    public interface ILocalFactory<T> where T : MonoBehaviour
    {
        T Create(string path, Transform container);
    }
}