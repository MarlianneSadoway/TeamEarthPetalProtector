using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyMovement : MonoBehaviour
{
    [Header("Fly Configuration")]
    public float speed = 3f; // Speed of the bug
    public float amplitude = 1.25f; // How wide the fly oscillates in the X direction
    public float frequency = 1.5f; // How fast the fly oscillates
    public Transform spawnRoot; // Transform to link bugs to prefab instance

    private float startX; // To store the initial X position
    private float timeElapsed; // Time tracking for sine wave movement
    private Rigidbody2D rb; // The bug's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    public float repelForce = 2.5f;
    private bool isRepelled = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the fly's initial random X position at the top of the screen
        startX = Random.Range(-1.5f, 1f);
        transform.localPosition = new Vector3(spawnRoot.position.x + startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the bug's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        //healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
{
    if (!isRepelled)
    {
        // Time-based horizontal oscillation
        timeElapsed += Time.deltaTime;

        // Calculate the new X position using a sine wave
        float newX = Mathf.Sin(timeElapsed * frequency) * amplitude;

        // Move the fly downward while also oscillating in the X direction
        transform.localPosition = new Vector3(newX, transform.localPosition.y - (speed * Time.deltaTime), 0f);
    }

    // Destroy the bug if it has gone off-screen
    if (transform.localPosition.x < -9f || transform.localPosition.x > 9f || transform.localPosition.y > 10f || transform.localPosition.y < -2f)
    {
        Destroy(gameObject);
    }
}


    // OnTriggerEnter2D is called when the fly collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // Reduce health
            if (healthController != null)
            {
                healthController.RemoveHeart();
            }

            // Set the beetle as repelled to stop normal movement
            isRepelled = true;

            // Delay repel 
            Invoke("Repel", 1f);
        }
    }

    // Method to repel the beetle in a random direction
    private void Repel()
    {
        // Randomly choose between left (-1) and right (1)
        float repelDirectionX = Random.Range(0, 2) == 0 ? -1f : 1f;

        // Set repel direction as left or right with some upward movement
        Vector2 repelDirection = new Vector2(repelDirectionX, 1f).normalized;

        // Apply a force to make the beetle fly away to the left or right
        rb.AddForce(repelDirection * repelForce, ForceMode2D.Impulse);
    }
}

