using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PreviewTrigger : MonoBehaviour
{

    public GameObject memoryPreview;
    private Image previewImage;
    private SelectMapMemory mapMem;

    void Start()
    {
        mapMem = GetComponent<SelectMapMemory>();
        memoryPreview = FindObjectOfType<MemoryPreview>(true).gameObject;
        previewImage = memoryPreview.GetComponent<Image>();
        // I added this in case I forgot to set the object
        if (memoryPreview!= null)
        {
            memoryPreview.SetActive(false);
        }
    }

    public void OnMouseEnter()
    {
        // Same here
        if (memoryPreview!= null)
        {
            previewImage.sprite = mapMem.memory.memoryPreview;
            memoryPreview.SetActive(true);
        }
    }

    public void OnMouseExit()
    {
        // and same here
        if (memoryPreview!= null)
        {
            memoryPreview.SetActive(false);
        }
    }
}
