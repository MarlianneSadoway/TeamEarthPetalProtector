using System.Collections;
using System.Collections.Generic;
using Unity.PlasticSCM.Editor.WebApi;
using UnityEngine;

public class MothMovement : MonoBehaviour
{
    [Header("Moth Configuration")]
    public Transform spawnRoot; // Transform to link bugs to prefab instance
    public List<Transform> pathPoints;
    private float _current;

    private Rigidbody2D rb; // The moth's Rigidbody2D component
    public HealthController healthController; // Reference to the HealthController script
    public float repelForce = 2.5f;
    private bool isRepelled = false;

    // Start is called before the first frame update
    void Start()
    {
        spawnRoot = gameObject.transform.parent.transform;
        // Set the moth's initial random X position at the top of the screen
        transform.localPosition = pathPoints[0].localPosition; // Y = 6 is off the top of the screen
        // Get the moth's Rigidbody2D component
        rb = GetComponent<Rigidbody2D>(); 

        // Get the HealthController from the scene
        //healthController = FindObjectOfType<HealthController>();
    }

    // Update is called once per frame
    void Update()
    {
        // Only move the moth if it hasn't been repelled
        if (!isRepelled)
        {
            _current = Mathf.MoveTowards(_current, 1, 0.15f*Time.deltaTime); // final parameter here is the speed, needs to be hard coded because using a variable breaks it for some reason
            transform.position = curveMovement(pathPoints[0].position, pathPoints[1].position, pathPoints[2].position, _current);
        }

        // Destroy the moth if it has gone off-screen so that there aren't a ton of extra moth gameObjects 
        if (transform.localPosition.y < -2f || transform.localPosition.x < -8f || transform.localPosition.x > 8f || transform.localPosition.y > 10f) // Destroy if off the bottom (Bottom is -5)
        {
            Destroy(gameObject);
        }
    }

    // OnTriggerEnter2D is called when the moth collides with the plant
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Plant"))
        {
            // Reduce health
            if (healthController != null)
            {
                healthController.RemoveHeart();
            }

            // Set the moth as repelled to stop normal movement
            isRepelled = true;

            // Delay repel 
            Invoke("Repel", 1f);
        }
    }

    // Method to repel the moth in a random direction
    private void Repel()
    {
        // Randomly choose between left (-1) and right (1)
        float repelDirectionX = Random.Range(0, 2) == 0 ? -1f : 1f;

        // Set repel direction as left or right with some upward movement
        Vector2 repelDirection = new Vector2(repelDirectionX, 1f).normalized;

        // Apply a force to make the moth fly away to the left or right
        rb.AddForce(repelDirection * repelForce, ForceMode2D.Impulse);
    }

    // Uses Lerp between three Transforms to create a curved path
    private Vector3 curveMovement(Vector3 A, Vector3 B, Vector3 C, float t)
    {
        Vector3 AtoB = Vector3.Lerp(A, B, t);
        Vector3 BtoC = Vector3.Lerp(B, C, t);
        Vector3 final = Vector3.Lerp(AtoB, BtoC, t);
        return final;
    }
}
