using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class InventorySystem : MonoBehaviour
{
    //==========~~~~~~~~~~===========~~~~~~~~~~==========
    //==========     Variable Delcaration      ==========
    //==========~~~~~~~~~~===========~~~~~~~~~~==========

    //Keeps track of current user's inventory
    public string[] inventory = { };

    //==========~~~~~~~~~~===========~~~~~~~~~~==========
    //==========    Displaying The Inventory   ==========
    //==========~~~~~~~~~~===========~~~~~~~~~~==========

    //Repeats every frame (is used to constantly update the inventory's display)
    private void Update()
    {
        //Creates a convenient reference for the TextMeshProUGUI object
        TextMeshProUGUI textMesh = GetComponent<TextMeshProUGUI>();
        
        //Creates a string to be displayed by TextMeshPro
        string currentDisplay = CurrentDisplay();

        //Sets TextMeshPro.text to the currentDisplay
        textMesh.text = currentDisplay;
    }

    //A function to create a string that contains every
    //inventory item, with a line break in between each item
    public string CurrentDisplay()
    {
        //Creates a string to be modified
        string currentDisplay = "";
        
        //Creates a loop that will repeat for as many variables that are in inventory[]
        for (int i = 0; i < inventory.Length; i++)
        {
            //Adds each inventory string to the end of currentDisplay
            currentDisplay += inventory[i];
            //Puts a line break between each inventory item
            currentDisplay += "\n";
        }
        //Returns finished string
        return currentDisplay;
    }

    //==========~~~~~~~~~~===========~~~~~~~~~~==========
    //==========      Adding Items To Inv      ==========
    //==========~~~~~~~~~~===========~~~~~~~~~~==========

    //A function to add any string to the end of the current inventory array
    public void PickUpItem(string item)
    {
        Array.Resize(ref inventory, inventory.Length + 1);
        //Adds string item to the end of array inventory
        inventory[inventory.Length - 1] = item;
    }
}