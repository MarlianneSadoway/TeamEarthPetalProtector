using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MothMovement : MonoBehaviour
{
    public float speed = 2.5f; // Speed of the moth
    public float amplitude = 0.5f; // How far the moth oscillates in the X direction
    public float frequency = 1f; // How fast the moth oscillates

    private float timeElapsed; // Time tracking for sine wave movement
    private Rigidbody2D rb; // The moth's Rigidbody2D component
    private HealthController healthController; // Reference to the HealthController script


    // Start is called before the first frame update
    void Start()
    {
        // Set the moth's initial random X position at the top of the screen
        float startX = Random.Range(-1.5f, 1f);
        transform.position = new Vector3(startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the moth's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Time-based horizontal oscillation
        timeElapsed += Time.deltaTime;

        // Calculate the new X position using a sine wave for subtle C-shaped movement
        float newX = Mathf.Sin(timeElapsed * frequency) * amplitude;

        // Move the moth downward while also oscillating in the X direction
        transform.position = new Vector3(newX, transform.position.y - (speed * Time.deltaTime), 0f);

        // Destroy the moth if it has gone off-screen so that there aren't a ton of extra moth gameObjects 
        if (transform.position.y < -6f) // Destroy if off the bottom (Bottom is -5)
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
