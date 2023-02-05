using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour
{
    public bool isInventoryOpen;
    public MemoryObject blankItem;
    public int inventorySize = 3;

    public int selectedObjectID = 0;
    public MemoryObject[] inventoryObjects;
    public GameObject[] inventoryButtons;
    // Start is called before the first frame update
    void Start()
    {
        isInventoryOpen = true;
        inventoryObjects = new MemoryObject[inventorySize];
        inventoryButtons = new GameObject[inventorySize];

        for(int i=0; i<inventorySize; i++)
        {
            inventoryObjects[i] = blankItem;
            inventoryButtons[i] = GameObject.Find("Memory ("+(i+1)+")");
        }

        UpdateInventory();
        ToggleInventory();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateInventory()
    {
        for(int i=0; i<inventorySize; i++)
        {
            inventoryButtons[i].GetComponent<Image>().sprite = inventoryObjects[i].memoryPreview;
        }

    }

    public void ToggleInventory()
    {
        if(isInventoryOpen == false)
        {

            foreach(GameObject inventoryButton in inventoryButtons)
            {
                inventoryButton.GetComponent<Button>().interactable = true;
                inventoryButton.GetComponent<Image>().enabled = true;
            }

            isInventoryOpen = true;
        }else if(isInventoryOpen == true)
        {

            foreach(GameObject inventoryButton in inventoryButtons)
            {
                inventoryButton.GetComponent<Button>().interactable = false;
                inventoryButton.GetComponent<Image>().enabled = false;
            }
            isInventoryOpen = false;
        }
    }
}
