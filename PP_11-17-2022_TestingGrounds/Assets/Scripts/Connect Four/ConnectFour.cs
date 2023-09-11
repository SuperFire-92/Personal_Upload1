using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFour : MonoBehaviour
{
    public char[,] connectFourBoard = { 
        { '-', '-', '-', '-', '-', '-', '-' }, 
        { '-', '-', '-', '-', '-', '-', '-' }, 
        { '-', '-', '-', '-', '-', '-', '-' }, 
        { '-', '-', '-', '-', '-', '-', '-' }, 
        { '-', '-', '-', '-', '-', '-', '-' }, 
        { '-', '-', '-', '-', '-', '-', '-' } };
    const int WIDTH = 7;
    const int HEIGHT = 6;
    public bool turn = true;
    public bool gameContinue = true;
    public GameObject winText;

    // Start is called before the first frame update
    void Start()
    {
        PrintBoard();
    }

    public void ResetBoard()
    {
        connectFourBoard = new char[,] {
        { '-', '-', '-', '-', '-', '-', '-' },
        { '-', '-', '-', '-', '-', '-', '-' },
        { '-', '-', '-', '-', '-', '-', '-' },
        { '-', '-', '-', '-', '-', '-', '-' },
        { '-', '-', '-', '-', '-', '-', '-' },
        { '-', '-', '-', '-', '-', '-', '-' } };
        turn = true;
        gameContinue = true;
        winText.GetComponent<ConnectFourText>().ResetText();
    }

    public void TakeTurn(int row)
    {
        if (gameContinue)
        {
            int maximumHeight = GetHeight(row);
            if (maximumHeight != -1)
            {
                connectFourBoard[maximumHeight, row] = (turn ? 'R' : 'Y');
                turn = (turn ? false : true);
            }
            gameContinue = !CheckWin(row, maximumHeight);
            if (gameContinue == false)
            {
                Debug.Log("Performing Win");
                winText.GetComponent<ConnectFourText>().Win(!turn);
            }
            PrintBoard();
        }
        
    }

    public int GetHeight(int row)
    {
        for (int i = HEIGHT - 1; i >= 0; i--)
        {
            if (connectFourBoard[i, row] == '-')
            {
                return i;
            }
        }
        return -1;
    }

    public bool CheckWin(int row, int maximumHeight)
    {
        int amount = 1;

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================   Vertical Win Check   ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        //Loops 3 times
        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row, maximumHeight + (i + 1)))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight + (i + 1), row] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //If a 4 long row was found
        if (amount >= 4)
        {
            //Return true
            return true;
        }

        //Reset amount
        amount = 1;

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================  Horizontal Win Check  ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        //Loops 3 times
        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row + (i + 1), maximumHeight))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight, row + (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //Loops 3 times
        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row - (i + 1), maximumHeight))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight, row - (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //If a 4 long row was found
        if (amount >= 4)
        {
            //Return true
            return true;
        }

        //Reset amount
        amount = 1;

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================  +Diagonal Win Check   ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        
        //(Technically the line is positive x negative y due to the way the array is layed out,
        // for sake of logic of code this is called + and the other will be called -)

        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row + (i + 1), maximumHeight + (i + 1)))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight + (i + 1), row + (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //Loops 3 times
        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row - (i + 1), maximumHeight - (i + 1)))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight - (i + 1), row - (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //If a 4 long row was found
        if (amount >= 4)
        {
            //Return true
            return true;
        }

        //Reset amount
        amount = 1;

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================  -Diagonal Win Check   ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row - (i + 1), maximumHeight + (i + 1)))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight + (i + 1), row - (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //Loops 3 times
        for (int i = 0; i < 4; i++)
        {
            //Checks to see if number is within array's boundaries
            if (InBoundaries(row + (i + 1), maximumHeight - (i + 1)))
            {
                //Checks if place in array holds the current person's
                if (connectFourBoard[maximumHeight - (i + 1), row + (i + 1)] == (!turn ? 'R' : 'Y'))
                {
                    amount++;
                }
                //If it does not
                else
                {
                    //Set i to be high enough to end the loop
                    i = 10;
                }
            }
        }

        //If a 4 long row was found
        if (amount >= 4)
        {
            //Return true
            return true;
        }

        return false;
    }

    public bool InBoundaries(int row, int column)
    {
        int test = 0;
        if ((row > -1 && row < 7))
        {
            test++;
        }
        if ((column > -1 && column < HEIGHT))
        {
            test++;
        }
        return (test == 2 ? true : false);
    }

    public void PrintBoard()
    {
        string board = "\n";
        for (int i = 0; i < HEIGHT; i++)
        {
            for (int j = 0; j < WIDTH; j++)
            {
                board = board + (connectFourBoard[i,j]) + " ";
            }
            board = board + "\n";
        }
        Debug.Log(board);
    }
}
