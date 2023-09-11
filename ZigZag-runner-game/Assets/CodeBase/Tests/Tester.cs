using UnityEngine;
using UnityEngine.Profiling;

public class Tester : MonoBehaviour
{
    [SerializeField] private GameObject _prefabTile;
    [SerializeField] private GameObject _prefabCube;
    
    
    private void Update()
    {
        Profiler.BeginSample("TileTester");
        if(Input.GetKeyDown(KeyCode.A))
            CreateTile();
        Profiler.EndSample();
        
        Profiler.BeginSample("CubeTester");
        if(Input.GetKeyDown(KeyCode.D))
            CreateCubes();
        Profiler.EndSample();
    }

    private void CreateCubes()
    {
        for (int i = 0; i < 1000; i++) 
            Instantiate(_prefabCube, new Vector3(0, 0, 0), Quaternion.identity);
    }

    private void CreateTile()
    {
        Instantiate(_prefabTile, new Vector3(0, 0, 0), Quaternion.identity);
    }
}
