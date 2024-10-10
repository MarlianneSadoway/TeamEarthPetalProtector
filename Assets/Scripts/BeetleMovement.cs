using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float speed = 2.5f; // Speed of the bug
    private Vector2 direction; // Direction to move
    private Rigidbody2D rb; // The bug's Rigidbody2D component

    private HealthController healthController; // Get the HealthController script

    // Start is called before the first frame update
    void Start()
    {
        // Set the bug's initial random X position at the top of the screen
        float randomX = Random.Range(-5f, 5f); 
        transform.position = new Vector3(randomX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the bug's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bug
        transform.Translate(Vector3.down * speed * Time.deltaTime);

        // Destroy the bug if it has gone off-screen so that there aren't a ton of extra bug gameObjects 
        // Based on the 3240x1920 screen size 
 
        if (transform.position.y > 6) // Off the top (Top is 5)
        {
            Destroy(gameObject); // Destroy the bug object
        }
        if (transform.position.y < -6) // Off the bottom (Bottom is -5)
        {
            Destroy(gameObject); // Destroy the bug object
        }

    }

    // OnTriggerEnter2D is called when the bug collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant")) // collision between gameObject (bug) and plant 
        {
            // The bug has reached the plant, so update the health bar
            if (healthController != null)
            {
                healthController.RemoveHeart(); // Call method to remove 1 heart from the health bar 
            }

            // Destroy the bug gameObject because it has reached the plant
            Destroy(gameObject);
        }
    }

}
