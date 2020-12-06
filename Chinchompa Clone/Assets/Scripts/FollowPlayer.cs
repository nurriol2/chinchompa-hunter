using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    //need access to the player position
    //Transform class has a position property
    public Transform PlayerTransform;
    
    //offset eucl. distance from player to camera
    private Vector3 _cameraOffset;
    
    //tunable camera motion, default to 0.5
    [Range(0.01f, 1.0f)]
    public float SmoothFactor = 0.5f;

    [Range(0.01f, 1.0f)]
    public float RotationSpeed = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        //calculate camera offset
        _cameraOffset = transform.position - PlayerTransform.position;
    }

    //LateUpdate is called after Update for all objects has already been called
    //objects may have been moved during Update
    void LateUpdate()
    {
        
        //new camera position
        Vector3 newPosition = PlayerTransform.position + _cameraOffset;

        //to avoid camera "skipping" interpolate the new position
        transform.position = Vector3.Slerp(transform.position, newPosition, SmoothFactor);

        //keep the camera focused on the player
        transform.LookAt(PlayerTransform);
        
        //camera orbit controlled by arrow keys
        //angles to change the camera rotation by these amounts
        Quaternion cameraTurnPhi = Quaternion.AngleAxis(Input.GetAxis("Horizontal")*RotationSpeed, Vector3.down);
        Quaternion cameraTurnTheta = Quaternion.AngleAxis(Input.GetAxis("Vertical")*RotationSpeed, Vector3.right);

        //turns camera around the world y-axis
        _cameraOffset = cameraTurnPhi * _cameraOffset;
        //turns camera around the world z-axis
        _cameraOffset = cameraTurnTheta * _cameraOffset;

    }
}
