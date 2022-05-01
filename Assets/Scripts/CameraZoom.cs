using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    Camera cam;
    float currentZoom; 
    float zoomIncrement = 3; 
    float zoomLerpSpeed = 10; 

    private void Start()
    {
        cam = Camera.main;
        currentZoom = cam.orthographicSize;
    }

    void Update()
    {
        float scrollData = Input.GetAxis("Mouse ScrollWheel");                                                     
        Debug.Log("Current zoom =" + currentZoom.ToString()); 
        currentZoom = Mathf.Clamp(currentZoom-scrollData*zoomIncrement, 2f, 5f); 

        cam.orthographicSize = Mathf.Lerp(cam.orthographicSize, currentZoom, zoomLerpSpeed * Time.deltaTime); 
        
    }
}
