using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MasterItemScript : MonoBehaviour
{
    public string itemName;
    public int itemAmount;
    public bool clickToPickUp;

    public GameObject cameraObject;
    public GameObject inventory;

    private void OnMouseDown()
    {
        Transform playerPos = cameraObject.GetComponent<Transform>();
        float dist = Vector3.Distance(playerPos.position, transform.position);
        if (clickToPickUp && dist < 10)
        {
            //Debug.Log("Attempting to add item " + itemName + " to inventory");
            inventory.GetComponent<InventorySystem>().PickUpItem(itemName);
        }
    }

    
}
