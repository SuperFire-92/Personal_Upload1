using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TicTacToeReset : MonoBehaviour
{
    public GameObject ticTacToe;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        ticTacToe.GetComponent<TicTacToe>().Reset();
    }
}
