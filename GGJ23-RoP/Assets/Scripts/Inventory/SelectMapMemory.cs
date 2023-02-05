using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMapMemory : MonoBehaviour
{
    public Inventory inventory;
    public MemoryObject memory;

    [HideInInspector]

    private Animator memoryFadeAnim;
    // Start is called before the first frame update
    void Start()
    {
        inventory = FindObjectOfType<Inventory>();
        memoryFadeAnim = GetComponentInParent<Animator>();
        memoryFadeAnim.ResetTrigger("Fade");
        GetComponent<SpriteRenderer>().sprite = memory.memoryPreview;
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
            memoryFadeAnim = GetComponentInParent<Animator>();
        }
    }

    public void OnMouseOver()
    {
        MemoryObject invMemory;
        if(Input.GetMouseButtonDown(0) && inventory.selectedObjectID > 0)
        {
            Debug.Log("Selected: "+memory.name);
            invMemory = inventory.inventoryObjects[inventory.selectedObjectID-1];
            inventory.SwapMemory(memory);
            memory = invMemory;
            GetComponent<SpriteRenderer>().sprite = memory.memoryPreview;
            memoryFadeAnim.SetTrigger("Fade");
        }
    }
}
