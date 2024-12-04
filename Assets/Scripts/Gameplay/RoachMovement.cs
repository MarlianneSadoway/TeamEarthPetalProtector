using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoachMovement : MonoBehaviour
{
    [Header("Roach Configuration")]
    public float speed = 0.8f; // Speed of the roach
    public float repelForce = 1.5f; // Force applied to repel the roach downward
    private Rigidbody2D rb; // The roach's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    private bool hasDamagedPlant = false; // Flag to prevent multiple heart losses
    private bool isRepelled = false; // Track if the roach is repelled

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the roach's initial localPosition at the left edge of the screen, just above the dirt 
        transform.localPosition = new Vector3(-2.78f, -2.27f, 10f); 

        // Get the roach's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRepelled)
        {
            float downwardSpeed = 0.06f;

            // Move the roach horizontally to the right and slightly downward
            transform.position += new Vector3(speed * Time.deltaTime, -downwardSpeed * Time.deltaTime, 0);
        }

        // Destroy the roach if it has gone off-screen
        if (transform.localPosition.y < -10f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the roach collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant") && !hasDamagedPlant)
        {
            // Reduce health
            if (healthController != null)
            {
                healthController.RemoveHeart();
            }

            // Set flag to prevent multiple heart losses
            hasDamagedPlant = true;

            // stop normal movement
            isRepelled = true;

            // Repel the roach downward after a delay 
            Invoke("RepelDownward", 1f);
        }
    }

    // Method to repel the roach downward
    private void RepelDownward()
    {
        // Set repel direction as downward
        Vector2 repelDirection = new Vector2(0f, -1f).normalized;

        // Apply a force to make the roach fly downward
        rb.AddForce(repelDirection * repelForce, ForceMode2D.Impulse);

        // Change the orientation of the roach to point downward
        transform.rotation = Quaternion.Euler(0, 0, 90); // Rotate 90 degrees to make it face downward

        // Adjust Z position to ensure visibility above dirt
        transform.position = new Vector3(transform.position.x, transform.position.y, 15f);
    }
}
