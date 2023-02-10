using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{

    public GameManager gameManager;
    public bool hasBeenSelected;
    public bool isMemPath;
    public MapGenerator mapGen;

    public Animator fadeAnim;
    public Transform startPoint;
    public Transform endPoint;

    public Transform mapMemPoint;
    public GameObject[] mapMemPrefabs;
    private GameObject mapMemPrefab;
    // Start is called before the first frame update
    void Start()
    {
        isMemPath = false;
        hasBeenSelected = false;
        startPoint = GetComponentInChildren<PathStartID>().gameObject.transform;
        endPoint = GetComponentInChildren<PathEndID>().gameObject.transform;
        if(GetComponentInChildren<memPointID>() != null)
        {
            mapMemPoint = GetComponentInChildren<memPointID>().gameObject.transform;
            isMemPath = true;
        }

        gameManager = FindObjectOfType<GameManager>();
        if(mapMemPoint == null)
        {
            mapMemPoint = endPoint;
        }
        mapGen = FindObjectOfType<MapGenerator>();
        fadeAnim = GetComponentInChildren<Animator>();

        mapMemPrefabs = mapGen.memoryPrefabs;

        if(isMemPath)
        {
            GameObject newMem;

            Debug.Log(mapMemPrefabs);

            mapMemPrefab = mapMemPrefabs[Random.Range(0, mapMemPrefabs.Length)];
            newMem = Instantiate(mapMemPrefab, mapMemPoint.position, Quaternion.identity);
            newMem.transform.parent = this.transform;
        }


    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && hasBeenSelected == false)
        {
            
            hasBeenSelected = true;
            gameManager.currentSubStage ++;
            mapGen.memoryPityCount++;
            Debug.Log("Current Choice is: "+gameManager.currentStage+"-"+gameManager.currentSubStage);
            mapGen.lockPaths();
            mapGen.GenerateMap(endPoint);
        }
    }
}
