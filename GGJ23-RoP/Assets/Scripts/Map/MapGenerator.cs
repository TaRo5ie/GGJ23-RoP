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
    private int memoryCutoff = 2; // maximum number of stages that can be generated before a memory shows up
    [HideInInspector]
    public int memoryPityCount = 0; // number of paths that have Not spawned a memory in this stage;
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
        // if(Input.GetKeyDown(KeyCode.Space))
        // {
        //     GenerateMap(pathStart);
        // }
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

        Debug.Log("Pity in "+(memoryCutoff-memoryPityCount )+" turns.");

        if(memoryPityCount < memoryCutoff)
        {
            numMemoryPaths = Random.Range(0,5); // 1 in 5 chance to roll a memory without pity
        }else
        {
            Debug.Log("Hit Memory Pity");
            numMemoryPaths = 1;
            memoryPityCount = 0;
        }

        
                Debug.Log("numMemoryPaths = "+numMemoryPaths);
        
        switch (numMemoryPaths)
        {
            case 1:
            
            memoryPityCount = 0;
            for(int i=0; i<Random.Range(minNumPaths, maxNumPaths); i++)
            {
                pathPrefab = pathPrefabs[Random.Range(0, pathPrefabs.Length)];
                memPathPrefab = memPathPrefabs[Random.Range(0, memPathPrefabs.Length)];
                if(i == (minNumPaths-1))
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

            default:

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
