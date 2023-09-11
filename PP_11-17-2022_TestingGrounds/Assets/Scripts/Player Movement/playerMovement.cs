using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerMovement : MonoBehaviour
{
    public float speed;
    public float jumpHeight;
    public GameObject player;
    //In FixedUpdate(), grabs the player's RigidBody vector information
    private Vector3 rbV;
    public float fallingRate;
    public int framesSinceStoppedFalling = 0;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void FixedUpdate()
    {
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================ X and Z Axis Movement  ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        //Grabs the rotation from the camera object
        float rotationY = (player.GetComponent<Transform>().eulerAngles.y);
        //Grabs the x and z numbers for the forward movement
        float zMovement = Mathf.Cos((rotationY * Mathf.PI) / 180);
        float xMovement = Mathf.Sin((rotationY * Mathf.PI) / 180);

        float zMovementSide = Mathf.Cos(((rotationY + 90) * Mathf.PI) / 180);
        float xMovementSide = Mathf.Sin(((rotationY + 90) * Mathf.PI) / 180);

        //Move forward if W key is pressed
        if (Input.GetKey(KeyCode.W))
        {
            MoveXZ(xMovement, zMovement);
        }

        //Move backwards if S key is pressed
        if (Input.GetKey(KeyCode.S))
        {
            MoveXZ(-xMovement, -zMovement);
        }

        //Move left is A key is pressed
        if (Input.GetKey(KeyCode.A))
        {
            MoveXZ(-xMovementSide, -zMovementSide);
        }

        //Move right if D key is pressed
        if (Input.GetKey(KeyCode.D))
        {
            MoveXZ(xMovementSide, zMovementSide);
        }

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================    Y Axis Movement     ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        rbV = GetComponent<Rigidbody>().velocity;
        //Checks if velocity is 0
        if (rbV.y == 0 && framesSinceStoppedFalling < 1000)
        {
            //Increases timer letting the game know the user is on the ground
            framesSinceStoppedFalling++;
        }

        //If the user is falling or going up
        else if (rbV.y > .5 || rbV.y < -.5)
        {
            //Sets the timer back to 0 (will not continue until the user's velocity is 0)
            framesSinceStoppedFalling = 0;
        }

        //If the user is pressing space and the ground timer has run for at least 1 frame
        if (Input.GetKey(KeyCode.Space) && framesSinceStoppedFalling > 0)
        {
            //Sets y velocity to 10
            GetComponent<Rigidbody>().velocity = new Vector3(rbV.x, jumpHeight, rbV.z);
            //Sets the timer back to 0
            framesSinceStoppedFalling = 0;
        }
        
        //Sets the rotation to the camera's rotation, mainly for use of the hitbox
        transform.eulerAngles = new Vector3(transform.eulerAngles.x, rotationY, transform.eulerAngles.z);

        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========
        //================       Respawning       ================
        //========~~~~~~~~========~~~~~~~~========~~~~~~~~========

        //If user has fallen too far down
        if (transform.position.y < -40.0f)
        {
            ResetPosition();
        }

        
    }

    void MoveXZ(double x, double z)
    {
        transform.position = new Vector3((float)(transform.position.x + (x * speed * Time.deltaTime)), transform.position.y, (float)(transform.position.z + (z * speed * Time.deltaTime)));
    }

    void ResetPosition()
    {
        transform.position = new Vector3(0.0f, 4.0f, 0.0f);
        GetComponent<Rigidbody>().velocity = new Vector3(0.0f, 0.0f, 0.0f);
    }
}
