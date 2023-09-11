using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraMovement : MonoBehaviour
{
    //For Camera Turning
    public float speedH = 2.0f;
    public float speedV = 2.0f;
    private float yaw = 0.0f;
    private float pitch = 0.0f;

    public bool releaseG = true;

    // Start is called before the first frame update
    void Start()
    {
        Cursor.lockState = CursorLockMode.None;
    }


    // Update is called once per frame
    void Update()
    {
        //Allows camera to follow mouse
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");

        if (pitch > 89.0f)
        {
            pitch = 89.0f;
        }
        if (pitch < -89.0f)
        {
            pitch = -89.0f;
        }
        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================       Lock Mouse       ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        if (Input.GetKey(KeyCode.G))
        {
            if (releaseG == true)
            {
                Cursor.lockState = (Cursor.lockState == CursorLockMode.None ? CursorLockMode.Locked : CursorLockMode.None);
                releaseG = false;
            }
        }
        else
        {
            releaseG = true;
        }
    }
}
