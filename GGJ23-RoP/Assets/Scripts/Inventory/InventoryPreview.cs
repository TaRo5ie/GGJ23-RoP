using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class InventoryPreview : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    
    public GameObject memoryPreview;
    public Vector3 customOffset;
    private Vector3 originalOffset;
    public MemoryObject blank;
    private Image previewImage;
    private SelectMapMemory mapMem;

    void Start()
    {
        
        mapMem = GetComponent<SelectMapMemory>();
        memoryPreview = FindObjectOfType<MemoryPreview>(true).gameObject;
        previewImage = memoryPreview.GetComponent<Image>();
        originalOffset = memoryPreview.GetComponent<MemoryPreview>().offset;
        // I added t$$anonymous$$s in case I forgot to set the tooltip object
        if (memoryPreview!= null)
        {
            memoryPreview.SetActive(false);
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
        memoryPreview.GetComponent<MemoryPreview>().offset = customOffset;
        //Debug.Log("Entered Button "+this.name);
        // Same here
        if (memoryPreview!= null)
        {
            previewImage.sprite = GetComponent<Image>().sprite;
            if(previewImage.sprite != blank.memoryPreview)
            {
                memoryPreview.SetActive(true);
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        
        memoryPreview.GetComponent<MemoryPreview>().offset = originalOffset;
        // and same here
        if (memoryPreview!= null)
        {
            memoryPreview.SetActive(false);
        }
    }
}
