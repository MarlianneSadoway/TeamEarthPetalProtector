using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeartFall : MonoBehaviour
{

    public float fallSpeed = 3.0f; // Speed that the heart falls

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        // Move the heart downwards
        transform.Translate(Vector3.down * fallSpeed * Time.deltaTime);

        // Check if the heart has moved off the bottom of the screen and destroy it
        if (transform.position.y <= -1620)
        {
            Destroy(gameObject); // Destroy the heart
        }

    }
}
