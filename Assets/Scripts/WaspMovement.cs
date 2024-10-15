using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspMovement : MonoBehaviour
{
    public float speed = 3f; // Speed of the wasp
    public float amplitude = 1.5f; // Amplitude for Z-shape movement
    public float frequency = 5f; // Frequency of the oscillation

    private float timeElapsed; // Time tracking for sine wave movement
    private Rigidbody2D rb; // The wasp's Rigidbody2D component
    private HealthController healthController; // Reference to the HealthController script

    // Start is called before the first frame update
    void Start()
    {
        // Set the wasp's initial position at the top of the screen
        transform.position = new Vector3(Random.Range(-1.5f, 1f), 6f, 0f); // Y = 6 is off the top of the screen

        // Get the wasp's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time-based horizontal oscillation
        timeElapsed += Time.deltaTime;

        // Calculate the new X position using a sine wave for smooth Z shape movement
        float newX = Mathf.Sin(timeElapsed * frequency) * amplitude;

        // Move the wasp downward while also oscillating in the X direction
        transform.position += new Vector3(newX * Time.deltaTime, -speed * Time.deltaTime, 0f);

        // Destroy the wasp if it has gone off-screen to prevent unnecessary gameObjects 
        if (transform.position.y < -6) // Destroy the wasp if it has gone off-screen at the bottom
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the wasp collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // The wasp has reached the plant, so update the health bar
            if (healthController != null)
            {
                healthController.RemoveHeart(); // Call method to remove 1 heart from the health bar
            }

            // Destroy the wasp gameObject because it has reached the plant
            Destroy(gameObject);
        }
    }
}
