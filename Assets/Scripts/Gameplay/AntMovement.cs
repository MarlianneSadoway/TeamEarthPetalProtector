using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    [Header("Ant Configuration")]
    public float speed = 1f; // Speed of the ant
    private Rigidbody2D rb; // The ant's Rigidbody2D component
    public Transform target;
    public HealthController healthController; // Reference to the HealthController script
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    private bool hasDamagedPlant = false; // Flag to prevent multiple heart losses

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the ant's initial localPosition at the left edge of the screen, just above the dirt 
        transform.localPosition = new Vector3(-2.78f, -1.999926f, 0f); // Y is on top of the dirt

        // Get the ant's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ant horizontally to the right
        transform.position += new Vector3(speed * Time.deltaTime, 0, 0);

        // Destroy the ant if it has gone off-screen
        if (transform.localPosition.y < -2f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the ant collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant") && !hasDamagedPlant)
        {
            // Reduce health
            if (healthController != null)
            {
                healthController.RemoveHeart();
            }

            // Set flag that bug has damaged plant so that it can't damage plant again 
            hasDamagedPlant = true;

            // Destroy ant because it has reached the plant
            Destroy(gameObject);

        }
    }

}

