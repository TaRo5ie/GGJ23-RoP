using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGenerator : MonoBehaviour
{
    private GameManager gameManager;
    public GameObject pathPrefab;
    public GameObject memPathPrefab;

    public GameObject[] pathPrefabs;
    public GameObject[] memPathPrefabs;
    public GameObject[] childPathPrefabs;
    public GameObject[] youngPathPrefabs;
    public GameObject[] middleAgePathPrefabs;
    public GameObject[] oldPathPrefabs;
    
    public Transform pathStart;

    [HideInInspector]
    public GameObject paths;

    public int maxNumPaths; //maximum number of paths that can be randomly generated for next stage
    public int minNumPaths;

    private int numMemoryPaths; // number of paths where a memory will spawn for that pivot point

    // Start is called before the first frame update
    void Start()
    {
        
        numMemoryPaths = 0;
        paths = new GameObject();
        gameManager = GetComponent<GameManager>();
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

        if(gameManager.currentSubStage > 5)
        {
            gameManager.currentStage ++;
            gameManager.currentSubStage = 0;
        }

        GameObject newPath;
        numMemoryPaths = Random.Range(0,2);
        
        switch (numMemoryPaths)
        {
            case 1:
            for(int i=0; i<Random.Range(minNumPaths, maxNumPaths); i++)
            {
                pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
                memPathPrefab = memPathPrefabs[Random.Range(0, memPathPrefabs.Length)];
                if(i == minNumPaths)
                {                    
                    newPath = Instantiate(memPathPrefab, pivotPoint.position, Quaternion.identity);
                }
                else
                {
                    newPath = Instantiate(pathPrefab, pivotPoint.position, Quaternion.identity);
                }
                newPath.transform.SetParent(paths.transform);
                newPath.transform.RotateAround(pivotPoint.position, Vector3.forward, i*(25+Random.Range(3,20))-25);
            }

            break;

            case 0:


            for(int i=0; i<Random.Range(minNumPaths, maxNumPaths); i++)
            {
                pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
                newPath = Instantiate(pathPrefab, pivotPoint.position, Quaternion.identity);
                newPath.transform.SetParent(paths.transform);
                newPath.transform.RotateAround(pivotPoint.position, Vector3.forward, i*(25+Random.Range(3,20))-25);
            }
            break;

            default:
            break;

        }
        
    }
}
