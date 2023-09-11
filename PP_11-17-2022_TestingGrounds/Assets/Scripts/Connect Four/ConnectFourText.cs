using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ConnectFourText : MonoBehaviour
{
    
    private void Start()
    {
        
    }
    public void Win(bool winner)
    {
        //Reference to TextMeshPro
        TextMeshPro textMesh = GetComponent<TextMeshPro>();

        //If white won
        if (winner == true)
        {
            //Tell the user white won
            textMesh.text = "White Wins";
        }

        //Else if black won
        else
        {
            //Tell the user black won
            textMesh.text = "Black Wins";
        }
    }
    public void ResetText()
    {
        //Reference to TextMeshPro
        TextMeshPro textMesh = GetComponent<TextMeshPro>();

        textMesh.text = "";
    }
}
