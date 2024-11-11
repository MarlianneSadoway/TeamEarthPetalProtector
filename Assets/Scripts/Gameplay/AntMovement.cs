using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AntMovement : MonoBehaviour
{
    [Header("Ant Configuration")]
    public float speed = 2f; // Speed of the ant
    public float repelForce = 2.5f; // Force applied to repel the ant after hitting the plant
    private Rigidbody2D rb; // The ant's Rigidbody2D component
    public Transform target;
    public HealthController healthController; // Reference to the HealthController script
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    private bool hasDamagedPlant = false; // Flag to prevent multiple heart losses

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the ant's initial random X localPosition at the top of the screen
        float startX = Random.Range(-1.5f, 1f);
        transform.localPosition = new Vector3(startX, 6f, 0f); // Y = 6 is off the top of the screen

        // Get the ant's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        // Move the ant downward on the y-axis
        transform.position = Vector2.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);

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

