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
    public GameObject Player;

    public GameObject fognew_3;
    GameObject fog1;
    float timer;
    bool hasDestroy;
    //when the fog catches the player, they both die!
    //when the fog catches the player, they both die!

    // Start is called before the first frame update
    void Start()
    {
        currentStage = 0;
        fog1 = Instantiate(fognew_3, new Vector3(0,50,0), Quaternion.identity);
        hasDestroy = false;
        currentSubStage = 0;
    }

    // Update is called once per frame
    void Update()
    {
        /*
        timer += Time.deltaTime;
        if (!hasDestroy)

            if (timer > 1000000f)
            {
                destroyFog();
                hasDestroy = true;
            }
        */
    }

    

    void destroyFog()
    {
        Destroy(fog1);
    }

    public void updatePivot()
    {
        //update currentPivot to PathManager endPoint of current path
    }

    /*   private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))
        {
            fog1.GetComponent<Fog>().isChasing = true;

        }

    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fog"))
        {
            fog1.GetComponent<Fog>().isChasing = false;

        }
    } */
}

