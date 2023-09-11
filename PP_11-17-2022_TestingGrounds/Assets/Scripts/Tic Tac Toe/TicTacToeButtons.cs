using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeButtons : MonoBehaviour
{
    public int height;
    public int width;
    public GameObject ticTacToe;
    Renderer rend;
    Color red = new(0.6698113f, 0.2180046f, 0.2180046f);
    Color blue = new(0.227394f, 0.6603774f, 0.5369573f);
    Color white = new(1.0f, 1.0f, 1.0f);

    private void Start()
    {
        rend = GetComponent<Renderer>();
    }

    private void Update()
    {
        TicTacToe tTT = ticTacToe.GetComponent<TicTacToe>();
        if (tTT.ticTacToeBoard[height, width] == 0)
        {
            rend.material.color = white;
        }
        if (tTT.ticTacToeBoard[height, width] == 1)
        {
            rend.material.color = red;
        }
        if (tTT.ticTacToeBoard[height, width] == 2)
        {
            rend.material.color = blue;
        }
    }

    private void OnMouseDown()
    {
        ticTacToe.GetComponent<TicTacToe>().TakeTurn(new int[] { height, width });
    }
}
