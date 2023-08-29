using UnityEngine;

namespace CodeBase.Tools
{
    [RequireComponent(typeof(MeshRenderer))]
    public class GpuInstancingEnabler : MonoBehaviour
    {
        private void Awake()
        {
            MaterialPropertyBlock materialPropertyBlock = new MaterialPropertyBlock();
            MeshRenderer meshRenderer = GetComponent<MeshRenderer>();
            meshRenderer.SetPropertyBlock(materialPropertyBlock);
        }
    }
}