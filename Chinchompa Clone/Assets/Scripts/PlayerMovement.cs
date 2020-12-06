using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerMovement : MonoBehaviour
{
    
    //variable for navigation mesh on the player
    NavMeshAgent agent;
    
    // Start is called before the first frame update
    void Start()
    {
        //f'n call to actually get the navmesh from the player
        agent = GetComponent<NavMeshAgent> ();
    }

    // Update is called once per frame
    void Update()
    {
        //find where the mouse is on the screen
        //send raycast from mouse screen position to a point in world space
        //send player to mouse position

        //0 is left click on mouse
        if (Input.GetMouseButtonDown(0))
        {
            
            //object that recieves information back from the raycast
            RaycastHit hit;

            //create ray from mouse screen position to pooint in the world 
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

            //out is an argument modifier that allows argument to be passed by reference instead of by value
            if (Physics.Raycast(ray, out hit, Mathf.Infinity))
            {
                //change the player position
                agent.SetDestination(hit.point);
            }
        }
    }
}
