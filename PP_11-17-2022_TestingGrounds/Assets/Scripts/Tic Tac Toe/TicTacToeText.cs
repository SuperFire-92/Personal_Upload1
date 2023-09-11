using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TicTacToeText : MonoBehaviour
{
    public void Win(bool winner)
    {
        //Create a reference to the TextMeshPro component
        TextMeshPro textMesh = GetComponent<TextMeshPro>();

        //If winner is red
        if (winner == true)
        {
            textMesh.text = "Red Wins";
        }

        //If winner is blue
        else
        {
            textMesh.text = "Teal Wins";
        }
    }

    public void ResetText()
    {
        //Create a reference to the TextMeshPro component
        TextMeshPro textMesh = GetComponent<TextMeshPro>();

        //Reset text
        textMesh.text = "";
    }
}
