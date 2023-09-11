using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToe : MonoBehaviour
{
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    //================  Variable declaration  ================
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

    //Stores the current status of the TicTacToe board
    public int[,] ticTacToeBoard = {
        { 0, 0, 0 }, 
        { 0, 0, 0 }, 
        { 0, 0, 0 } };
    //An int to easily reference the size of the TicTacToe board
    const int SIZE = 3;
    //A bool to keep track of who's turn it is
    bool turn = true;
    bool gameContinue = true;
    public GameObject winText;

    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    //================      Turn Script       ================
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

    //The main script that will run any time the user presses on tile
    public void TakeTurn(int[] position)
    {
        //Prevents the turn from occurring if the tile has already been used
        if (ticTacToeBoard[position[0], position[1]] == 0 && gameContinue)
        {
            changeBoardInPosition(position);
            gameContinue = !WinCheck();
            if (gameContinue == false)
            {
                winText.GetComponent<TicTacToeText>().Win(turn);
            }
            turn = (turn ? false : true);
        }
    }

    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    //================       Win Check        ================
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    
    public bool WinCheck()
    {
        //Vertical check
        for (int i = 0; i < SIZE; i++)
        {
            if (ticTacToeBoard[i, 0] == Turn12() && 
                ticTacToeBoard[i, 1] == Turn12() && 
                ticTacToeBoard[i, 2] == Turn12())
            {
                return true;
            }
        }

        //Horizontal check
        for (int i = 0; i < SIZE; i++)
        {
            if (ticTacToeBoard[0, i] == Turn12() && 
                ticTacToeBoard[1, i] == Turn12() && 
                ticTacToeBoard[2, i] == Turn12())
            {
                return true;
            }
        }

        //Diagonal check
        if (ticTacToeBoard[0, 0] == Turn12() && 
            ticTacToeBoard[1, 1] == Turn12() && 
            ticTacToeBoard[2, 2] == Turn12())
        {
            return true;
        }
        if (ticTacToeBoard[0, 2] == Turn12() &&
            ticTacToeBoard[1, 1] == Turn12() &&
            ticTacToeBoard[2, 0] == Turn12())
        {
            return true;
        }

        return false;
    }

    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    //================      Reset Board       ================
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

    public void Reset()
    {
        turn = true;
        gameContinue = true;
        winText.GetComponent<TicTacToeText>().ResetText();
        ticTacToeBoard = new int[,] {
        { 0, 0, 0 },
        { 0, 0, 0 },
        { 0, 0, 0 } };
    }

    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
    //================    Simple Functions    ================
    //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

    //Sets the position on the board to the correlated number of the current turn
    public void changeBoardInPosition(int[] position)
    {
        ticTacToeBoard[position[0],position[1]] = Turn12();
    }

    //Translates the turn from true and false to 1 and 2 respectively
    public int Turn12()
    {
        if (turn == true)
        {
            return 1;
        }
        else
        {
            return 2;
        }
    }

}
