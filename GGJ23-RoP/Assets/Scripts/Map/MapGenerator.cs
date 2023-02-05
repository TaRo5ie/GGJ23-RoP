using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject pathPrefab;

    public GameObject[] pathPrefabs;
    
    public Transform pathStart;

    [HideInInspector]
    public GameObject paths;

    public int maxNumPaths; //maximum number of paths that can be randomly generated for next stage
    public int minNumPaths;
    // Start is called before the first frame update
    void Start()
    {
        paths = new GameObject();
        GenerateMap(pathStart);
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            GenerateMap(pathStart);
        }
    }

    public void GenerateMap(Transform pivotPoint)
    {
        GameObject newPath;
        for(int i=0; i<Random.Range(minNumPaths, maxNumPaths); i++)
        {
            pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
            newPath = Instantiate(pathPrefab, pivotPoint.position, Quaternion.identity);
            newPath.transform.SetParent(paths.transform);
            newPath.transform.RotateAround(pivotPoint.position, Vector3.forward, i*(25+Random.Range(3,20))-25);
        }
        
    }
}
