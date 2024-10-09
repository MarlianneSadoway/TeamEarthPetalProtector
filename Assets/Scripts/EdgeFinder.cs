using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EdgeFinder : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        // Get the camera
        Camera mainCamera = Camera.main;

        // Calculate the corners of the viewport
        Vector3 bottomLeft = mainCamera.ViewportToWorldPoint(new Vector3(0, 0, mainCamera.nearClipPlane));
        Vector3 topRight = mainCamera.ViewportToWorldPoint(new Vector3(1, 1, mainCamera.nearClipPlane));

        // Display the positions
        Debug.Log("Bottom Left: " + bottomLeft);
        Debug.Log("Top Right: " + topRight);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
