using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    public float speed = 2f; // Speed of the beetle
    private Transform target; // Target position (Transform Station)
    private Rigidbody2D rb; // The beetle's Rigidbody2D component
    private HealthController healthController; // Reference to the HealthController script

    // Start is called before the first frame update
    void Start()
    {
        // Set the beetle's initial random X position at the top of the screen
        float startX = Random.Range(-1.5f, 1f);
        transform.position = new Vector3(startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the beetle's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Find the Transform Station in the scene
        target = GameObject.Find("TransformStation").transform;

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the beetle downward
        transform.position += Vector3.down * speed * Time.deltaTime;

        // Destroy the beetle if it has gone off-screen to prevent unnecessary gameObjects 
        if (transform.position.y < -6f) // Destroy if off the bottom (Bottom is -5)
        {
            Destroy(gameObject);
        }
    }

     // OnTriggerEnter2D is called when the fly collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // The fly has reached the plant, so update the health bar
            if (healthController != null)
            {
                healthController.RemoveHeart(); // Call method to remove 1 heart from the health bar
            }

            // Destroy the fly gameObject because it has reached the plant
            Destroy(gameObject);
        }
    }
}
