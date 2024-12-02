using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoachMovement : MonoBehaviour
{
    [Header("Roach Configuration")]
    public float speed = 0.8f; // Speed of the roach
    private Rigidbody2D rb; // The roach's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    private bool hasDamagedPlant = false; // Flag to prevent multiple heart losses

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the roach's initial localPosition at the left edge of the screen, just above the dirt 
        transform.localPosition = new Vector3(-2.78f, -2.27f, 0f); // Y is on top of the dirt

        // Get the roach's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        float downwardSpeed = 0.06f;

        // Move the roach horizontally to the right and slightly downward
        transform.position += new Vector3(speed * Time.deltaTime, -downwardSpeed * Time.deltaTime, 0);

        // Destroy the roach if it has gone off-screen
        if (transform.localPosition.y < -5f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f)
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

            // Set flag that roach has damaged plant so that it can't damage plant again 
            hasDamagedPlant = true;

            // Destroy roach because it has reached the plant
            Destroy(gameObject);

        }
    }

}

