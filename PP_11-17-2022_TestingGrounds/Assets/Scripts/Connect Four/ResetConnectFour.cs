using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetConnectFour : MonoBehaviour
{
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
        connectFour.GetComponent<ConnectFour>().ResetBoard();
    }
}
