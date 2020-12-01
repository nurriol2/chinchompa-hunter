using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    public float walkSpeed = 8f;
    public float jumpSpeed = 7f;
    
    //player rigid body - access to accurate physics 
    Rigidbody rb;

    //colider object
    Collider coll;

    //jump flag - if a jump started
    bool pressedJump = false;

    //acccess the HUD
    public HudManager hud;
    
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        coll = GetComponent<Collider>();
        
        //refresh score on game start
        hud.Refresh();
    }

    // Update is called once per frame
    void Update()
    {
        //handle player walking
        WalkHandler();

        //handle player jumping
        JumpHandler();
    }

    void WalkHandler()
    {
        //set x nad z velocities to 0
        rb.velocity = new Vector3(0f, rb.velocity.y, 0f);

        //distance
        float distance = walkSpeed * Time.deltaTime;

        //horizontal input
        float hAxis = Input.GetAxis("Horizontal");

        //vertical input
        float vAxis = Input.GetAxis("Vertical");

        //motion vector
        Vector3 movement = new Vector3(vAxis*distance, 0f, -1*hAxis*distance);

        //current player position vector
        Vector3 currPosition = transform.position;

        //new position vector
        Vector3 newPosition = currPosition + movement;

        //apply movement to rigid body
        rb.MovePosition(newPosition);

    }

    void JumpHandler()
    {
        //jump axis (x in our case)
        float jAxis = Input.GetAxis("Jump");

        //check if grounded
        bool isGrounded = CheckGrounded();

        if (jAxis>0f)
        {
            if (!pressedJump && isGrounded)
            {
                pressedJump = true;
                 
                Vector3 jumpVector = new Vector3(0f, jumpSpeed, 0f);

                //change the velocity of the player
                rb.velocity = rb.velocity + jumpVector;
            }
        }
        else
        {
            pressedJump = false;
        }
    }

    bool CheckGrounded()
    {
        //object size in each dimension
        float sizeX = coll.bounds.size.x;
        float sizeY = coll.bounds.size.z;
        float sizeZ = coll.bounds.size.z;

        //corners of the game object
        //adding 0.01 so there's space between the point and the floor
        Vector3 corner1 = transform.position + new Vector3(sizeX/2, -sizeY/2+0.01f, sizeZ/2);
        Vector3 corner2 = transform.position + new Vector3(-sizeX/2, -sizeY/2+0.01f, sizeZ/2);
        Vector3 corner3 = transform.position + new Vector3(sizeX/2, -sizeY/2+0.01f, -sizeZ/2);
        Vector3 corner4 = transform.position + new Vector3(-sizeX/2, -sizeY/2+0.01f, -sizeZ/2);

        //send a short ray down the cube on all 4 corners to detect ground
        bool grounded1 = Physics.Raycast(corner1, new Vector3(0, -1, 0), 0.01f);
        bool grounded2 = Physics.Raycast(corner2, new Vector3(0, -1, 0), 0.01f);
        bool grounded3 = Physics.Raycast(corner3, new Vector3(0, -1, 0), 0.01f);
        bool grounded4 = Physics.Raycast(corner4, new Vector3(0, -1, 0), 0.01f);

        //if a corner is grounded, the object is grounded
        return (grounded1 || grounded2 || grounded3 || grounded4);
    }

    void OnTriggerEnter(Collider collider)
    {
        //check if player ran into a coin
        if (collider.gameObject.tag=="Coin")
        {
            print("Grabbing coin");

            //increase the game score
            GameManager.instance.IncreaseScore(1);

            //increase the score text
            hud.Refresh();

            //destroy the coin game object in the scene
            Destroy(collider.gameObject);
        }

        //check if player ran into an enemy
        else if (collider.gameObject.tag=="Enemy")
        {
            print("Game Over");
            SceneManager.LoadScene("Game Over");
        }

        //check if player reached the level goal
        else if (collider.gameObject.tag=="Goal")
        {
            print("Next Level!");
            GameManager.instance.IncreaseLevel();
        }
    }

}
