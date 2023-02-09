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
    public GameObject[] memoryPrefabs;
    public GameObject[] childMemoryPrefabs;
    public GameObject[] youngMemoryPrefabs;
    public GameObject[] middleAgeMemoryPrefabs;
    public GameObject[] oldMemoryPrefabs;
    
    public Transform pathStart;

    [HideInInspector]
    public GameObject paths;

    public int maxNumPaths; //maximum number of paths that can be randomly generated for next stage
    public int minNumPaths;

    private int maxSubStages = 5; // maximum number of stages that can be generated before current stage # goes up

    private int numMemoryPaths; // number of paths where a memory will spawn for that pivot point

    // Start is called before the first frame update
    void Start()
    {
        
        numMemoryPaths = 0;
        memoryPrefabs = oldMemoryPrefabs; // start with old memories

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

        if(gameManager.currentSubStage > maxSubStages)
        {
            gameManager.currentStage ++; // increases current stage of life after a certain number of stages have passed
            gameManager.currentSubStage = 0;

            switch (gameManager.currentStage)
            {
                case 1:
                memoryPrefabs = middleAgeMemoryPrefabs;
                break;

                case 2:
                memoryPrefabs = youngMemoryPrefabs;
                break;

                case 3:
                memoryPrefabs = childMemoryPrefabs;
                break;
            }
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

        }
        
    }

    public void lockPaths()
    {
        PathManager[] currentPaths;
        currentPaths = paths.GetComponentsInChildren<PathManager>();

        foreach(PathManager path in currentPaths)
        {
            if(path.hasBeenSelected == false)
            {
                path.hasBeenSelected = true;
            }
        }
        
    }
}
