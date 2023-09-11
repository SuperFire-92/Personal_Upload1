using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConnectFourPiece : MonoBehaviour
{
    public int posX;
    public int posY;
    
    public GameObject connectFour;
    Renderer test;
    Renderer rend;

    // Start is called before the first frame update
    void Start()
    {
        posX = (int)((transform.localPosition.x + 1.25f) * (4f / 3f));
        posY = (int)((transform.localPosition.y + 1f) * (4f / 3f) * -1);
        test = GetComponent<MeshRenderer>();
        rend = GetComponent<Renderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (connectFour.GetComponent<ConnectFour>().connectFourBoard[posY, posX] == '-')
        {
            test.enabled = false;
        }
        if (connectFour.GetComponent<ConnectFour>().connectFourBoard[posY, posX] == 'R')
        {
            test.enabled = true;
            rend.material.color = new Color(1.0f, 1.0f, 1.0f);
        }
        if (connectFour.GetComponent<ConnectFour>().connectFourBoard[posY, posX] == 'Y')
        {
            test.enabled = true;
            rend.material.color = new Color(0.0f, 0.0f, 0.0f);
        }
    }
}
