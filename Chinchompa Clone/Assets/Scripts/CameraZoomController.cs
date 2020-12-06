using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoomController : MonoBehaviour
{   
    //access the camera object
    private Camera _camera;

    //zooming effect by changing the field of view (FOV)
    //variable to hold FOV changes
    private float _currentFOV;

    //zooming parameters
    //these are all playtested values
    private float _minFOV = 16.0f;
    private float _maxFOV = 75.0f;
    private float _zoomRate = 5.0f;
    
    // Start is called before the first frame update
    void Start()
    {
        //set the starting FOV
        _camera = GetComponent<Camera>();
    }

    // Update is called once per frame
    void Update()
    {
        WheelScroll();
    }

    public void WheelScroll()
    {
        _currentFOV = _camera.fieldOfView;
        //amount to change determined by using scroll wheel
        float scroll = Input.GetAxis("Mouse ScrollWheel");

        //scale the amount to scroll
        _currentFOV -= scroll*_zoomRate;
        
        //set boundaries on the amount of scrolling
        _currentFOV = Mathf.Clamp(_currentFOV, _minFOV, _maxFOV);
        _camera.fieldOfView = _currentFOV;
    }
}
