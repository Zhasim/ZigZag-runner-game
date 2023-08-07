using UnityEngine;

namespace CodeBase.Infrastructure.AssetManagement
{
    public interface IResourceLoader
    {
        GameObject Load(string path);
    }
}