using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private GameManager gameManager;

    public GameObject pathPrefab;
    
    private Transform pathStart;

    public int maxNumPaths; //maximum number of paths that can be randomly generated for next stage
    public int minNumPaths;
    // Start is called before the first frame update
    void Start()
    {
        GenerateMap(pathStart);
    }

    void Update()
    {

    }

    public void GenerateMap(Transform pivotPoint)
    {
        GameObject newPath;
        for(int i=0; i<Random.Range(minNumPaths, maxNumPaths); i++)
        {
            
            newPath = Instantiate(pathPrefab, new Vector3(0, 0, 0), Quaternion.identity);
            newPath.transform.RotateAround(pivotPoint.position, Vector3.up, Random.Range(-40, 40));
        }
        
    }
}
