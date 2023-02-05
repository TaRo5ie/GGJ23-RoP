using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public bool hasBeenSelected;
    public MapGenerator mapGen;
    public Transform startPoint;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        hasBeenSelected = false;
        startPoint = GetComponentInChildren<PathStartID>().gameObject.transform;
        endPoint = GetComponentInChildren<PathEndID>().gameObject.transform;
        mapGen = FindObjectOfType<MapGenerator>();
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void OnMouseOver()
    {
        if(Input.GetMouseButtonDown(0) && hasBeenSelected == false)
        {
            mapGen.GenerateMap(endPoint);
            hasBeenSelected = true;
        }
    }
}
