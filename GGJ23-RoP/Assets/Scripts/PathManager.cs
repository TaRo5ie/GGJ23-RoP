using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathManager : MonoBehaviour
{
    public Transform startPoint;
    public Transform endPoint;
    // Start is called before the first frame update
    void Start()
    {
        startPoint = GetComponentInChildren<PathStartID>().gameObject.transform;
        endPoint = GetComponentInChildren<PathEndID>().gameObject.transform;
    }

    // Update is called once per frame
    void Update()
    {
    }
}
