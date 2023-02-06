using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectMapMemory : MonoBehaviour
{
    private GameManager gameManager;

    private PathManager pathManager;
    public Inventory inventory;
    public MemoryObject memory;
    public SpriteRenderer memSpriteRender;
    // Start is called before the first frame update
    void Start()
    {
        gameManager = FindObjectOfType<GameManager>();
        inventory = FindObjectOfType<Inventory>();
        memSpriteRender = GetComponent<SpriteRenderer>();
        memSpriteRender.sprite = memory.memoryPreview;
        
        pathManager.fadeAnim.ResetTrigger("Fade");
    }

    // Update is called once per frame
    void Update()
    {
        if(inventory == null)
        {
            inventory = FindObjectOfType<Inventory>();
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
            pathManager.fadeAnim.SetTrigger("Fade");

            gameManager.currentSubStage ++;
        }
    }

}
