using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float topLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float timeOffset = 0.5f;
  
    void Update() 
    {
      
        Vector3 startPosition = transform.position; 

        Vector3 mousePos = Input.mousePosition;
        mousePos.z = Camera.main.nearClipPlane; 
        Vector3 desiredPosition = Camera.main.ScreenToWorldPoint(mousePos);
        desiredPosition.z = -10;

       
        transform.position = Vector3.Lerp(startPosition,
            new Vector3(
            Mathf.Clamp(desiredPosition.x, leftLimit, rightLimit),
            Mathf.Clamp(desiredPosition.y,  bottomLimit, topLimit), // order matters! 
            desiredPosition.z
            ), 
            timeOffset * Time.deltaTime); 

    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(leftLimit, bottomLimit)); 
        Gizmos.DrawLine(new Vector2(rightLimit, topLimit), new Vector2(rightLimit, bottomLimit)); 
        Gizmos.DrawLine(new Vector2(leftLimit, topLimit), new Vector2(rightLimit, topLimit));
        Gizmos.DrawLine(new Vector2(leftLimit, bottomLimit), new Vector2(rightLimit, bottomLimit)); 

    }
}
