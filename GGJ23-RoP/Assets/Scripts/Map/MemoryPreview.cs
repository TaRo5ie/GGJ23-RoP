using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MemoryPreview : MonoBehaviour
{
    
    public Canvas myCanvas;
    public Vector3 offset;
 // Update is called once per frame
    void Update ()
    {
        transform.position = Input.mousePosition + offset;
    }
}
