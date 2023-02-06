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
    public GameObject fog;
    GameObject fog1;
    float timer;
    bool hasDestroy;
 //when the fog catches the player, they both die!
    //when the fog catches the player, they both die!
    
    // Start is called before the first frame update
    void Start()
    {
        currentStage = 0;
        fog1= Instantiate(fog, currentPivot.position, Quaternion.identity);
        hasDestroy = false;

        currentSubStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(!hasDestroy)

            if(timer > 10f) {
                destroyFog();
                hasDestroy = true;
            }
    }

    void destroyFog()
    {
        Destroy(fog1);
    }

    public void updatePivot()
    {
        //update currentPivot to PathManager endPoint of current path
    }
}
