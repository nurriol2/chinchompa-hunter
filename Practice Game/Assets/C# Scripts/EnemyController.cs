using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    
    //maximum directional movement (meters)
    public float rangeX = 2f;

    //speed
    public float speed = 3f;

    //initial direction
    public float direction = 1f;

    //initial position
    Vector3 initialPosition;
    
    // Start is called before the first frame update
    void Start()
    {
        initialPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //amount of motion
        float movementX = direction * speed * Time.deltaTime;

        //new position
        float newX = transform.position.x + movementX;

        //check whether the limt would be passed
        if(Mathf.Abs(newX-initialPosition.x)>rangeX)
        {
            //move the other direction
            direction *= -1;
        }

        else
        {
            transform.Translate(new Vector3(movementX, 0, 0));
        }
    }
}
