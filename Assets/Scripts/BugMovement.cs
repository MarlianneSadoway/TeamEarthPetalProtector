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
        // Set direction randomly to left or right
        direction = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;

        // Get the bug's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bug
        transform.Translate(direction * speed * Time.deltaTime);

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
