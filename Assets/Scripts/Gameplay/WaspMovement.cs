using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaspMovement : MonoBehaviour
{
    [Header("Wasp Configuration")]
    public float speed = 3f; // Speed of the wasp   
    public float amplitude = 1.5f; // Amplitude for Z-shape movement
    public float frequency = 5f; // Frequency of the oscillation
    public Transform spawnRoot; // Transform to link bugs to prefab instance

    private float timeElapsed; // Time tracking for sine wave movement
    private Rigidbody2D rb; // The wasp's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    public float repelForce = 2.5f;
    private bool isRepelled = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the wasp's initial position at the top of the screen
        transform.localPosition = new Vector3(spawnRoot.localPosition.x + Random.Range(-1.5f, 1f), 6f, 0f); // Y = 6 is off the top of the screen

        // Get the wasp's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        //healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only move the wasp if it hasn't been repelled
        if (!isRepelled)
        {
            // Time-based horizontal oscillation
            timeElapsed += Time.deltaTime;

            // Calculate the new X position using a sine wave for smooth Z shape movement
            float newX = Mathf.Sin(timeElapsed * frequency) * amplitude;

            // Move the wasp downward while also oscillating in the X direction
            transform.localPosition += new Vector3(newX * Time.deltaTime, -speed * Time.deltaTime, 0f);
        }

        // Destroy the wasp if it has gone off-screen to prevent unnecessary gameObjects 
        if (transform.localPosition.y < -6f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f) // Destroy the wasp if it has gone off-screen at the bottom
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the wasp collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // Reduce health
            if (healthController != null)
            {
                healthController.RemoveHeart();
            }

            // Mark the wasp as repelled to stop normal movement
            isRepelled = true;

            // Delay repel 
            Invoke("Repel", 1f);
        }
    }

    // Method to repel the wasp in a random direction
    private void Repel()
    {
        // Randomly choose between left (-1) and right (1)
        float repelDirectionX = Random.Range(0, 2) == 0 ? -1f : 1f;

        // Set repel direction as left or right with some upward movement
        Vector2 repelDirection = new Vector2(repelDirectionX, 1f).normalized;

        // Apply a force to make the wasp fly away to the left or right
        rb.AddForce(repelDirection * repelForce, ForceMode2D.Impulse);
    }
}
