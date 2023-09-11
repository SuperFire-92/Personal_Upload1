using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonScript : MonoBehaviour
{
    //Should be between 0 and 6
    public int buttonNumber;
    public GameObject connectFour;



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
        connectFour.GetComponent<ConnectFour>().TakeTurn(buttonNumber);
    }
}
