using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IAssetProvider
    {
        GameObject Instantiate(string path);
        GameObject InstantiateCheck(string path);
        GameObject Instantiate(string path, Vector3 at);
    }
}