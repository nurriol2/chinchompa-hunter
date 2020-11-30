using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
    //do we need to declare the type twice?
    public float rotationSpeed = 100f;
    
    // Update is called once per frame
    void Update()
    {
        //the angle of rotation
        float angle = rotationSpeed * Time.deltaTime;

        //axis to rotate on
        //Space.World means relative to the world not the object itself
        transform.Rotate(Vector3.up * angle, Space.World);
    }
}
