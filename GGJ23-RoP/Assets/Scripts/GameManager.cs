using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int numStages = 4;
    public int currentStage;

    public int currentSubStage;

    public Transform currentPivot;
    public GameObject currentPathPrefab;
    
    // Start is called before the first frame update
    void Start()
    {
        currentStage = 0;
        currentSubStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void updatePivot()
    {
        //update currentPivot to PathManager endPoint of current path
    }
}
