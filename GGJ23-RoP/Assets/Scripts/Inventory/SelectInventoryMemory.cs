using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class SelectInventoryMemory : MonoBehaviour, IDeselectHandler //This Interface is required to receive OnDeselect callbacks.
{
    public Inventory inventory;
    public int objectInventoryID;
    // Start is called before the first frame update
    void Start()
    {
        inventory = GetComponentInParent<Inventory>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnDeselect(BaseEventData data)
    {
        inventory.selectedObjectID = 0;
        Debug.Log("Deselected");
    }

    public void InventorySelect()
    {
        inventory.selectedObjectID = objectInventoryID;
    }
}
