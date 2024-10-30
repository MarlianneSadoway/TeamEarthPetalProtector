using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeetleMovement : MonoBehaviour
{
    [Header("Beetle Configuration")]
    public float speed = 2f; // Speed of the beetle
    public float repelForce = 2.5f; // Force applied to repel the beetle after hitting the plant
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    private Rigidbody2D rb; // The beetle's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    private Vector3 targetPosition = Vector3.zero; // Target position (0, 0)
    private bool isRepelled = false; // Track if the beetle is repelled

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the beetle's initial random X position at the top of the screen
        float startX = Random.Range(-1.5f, 1f);
        transform.localPosition = new Vector3(spawnRoot.localPosition.x + startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the beetle's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();

        // Get the HealthController from the scene
        //healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!isRepelled)
        {
            // Move the beetle toward the target
            Vector3 direction = (targetPosition - transform.localPosition).normalized;
            transform.localPosition += direction * speed * Time.deltaTime;
        }

        // Destroy the beetle if it has gone off-screen
        if (transform.localPosition.y < -6f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the beetle collides with the plant
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
