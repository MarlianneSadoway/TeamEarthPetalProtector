using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEditor.UI;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    [Header("Bug Prefabs")]
    public GameObject beetlePrefab; // Reference to the Beetle prefab
    public GameObject flyPrefab; // Reference to the Fly prefab
    public GameObject waspPrefab; // Reference to the Wasp prefab
    public GameObject mothPrefab; // Reference to the Moth prefab

    [Header("Spawn Configuration")]
    public float spawnInterval = 5f; // Time between spawns
    public float spawnDuration = 90f; // Total duration of spawning 
    public float spawnDistance = 2f; // Distance from the camera to spawn bugs
    public HealthController healthController;
    public Transform[] bezierPoints;

    private float spawnTime; // Timer to track elapsed spawn time

    void Start()
    {
        spawnTime = 0f; // Initialize the spawn timer
        StartCoroutine(SpawnBugs());
    }

    IEnumerator SpawnBugs()
    {
        while (spawnTime < spawnDuration) // Check if total spawn duration is not reached
        {
            SpawnBug(); // Spawn a bug
            spawnTime += spawnInterval; // Update the spawn time
            yield return new WaitForSeconds(spawnInterval); // Wait for the specified interval
        }
    }

    void SpawnBug()
    {
        // Fixed Y position at the top of the screen
        float yPosition = 6f; 

        // Random X position between -1.5 and 1
        float xPosition = Random.Range(-1.5f, 1f); 

        // Set the spawn position with X on the left or right, and random Y
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

        // Randomly choose which bug prefab to spawn (0 = beetle, 1 = fly, 2 = wasp, 3 = moth)
        int bugType = Random.Range(0,4);
        GameObject selectedBugPrefab = (bugType == 0) ? beetlePrefab : (bugType == 1) ? flyPrefab : (bugType == 2) ? waspPrefab : mothPrefab; // Moth
        Debug.Log(bugType);
        // Instantiate the selected bug at the chosen position
        GameObject newBug = Instantiate(selectedBugPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
        
        // Assign the health controller to the new bug so that it references the correct instance
        switch(bugType)
        {
            case 0:
                newBug.GetComponent<BeetleMovement>().healthController = healthController;
                newBug.GetComponent<BeetleMovement>().target = bezierPoints[3];
                
                break;
            case 1:
                newBug.GetComponent<FlyMovement>().healthController = healthController;
                break;
            case 2:
                newBug.GetComponent<WaspMovement>().healthController = healthController;
                break;
            default:
                newBug.GetComponent<MothMovement>().healthController = healthController;
                // Decide if the moth will fly left or right, there might be a cleaner way to write this
                // but it is what it is
                int dir = Random.Range(0,2);
                // Add appropriate transforms to the moth pathPoints
                switch (dir)
                {
                    case 0: // Right
                        newBug.GetComponent<MothMovement>().pathPoints = new List<Transform>
                        {
                            bezierPoints[0],
                            bezierPoints[1],
                            bezierPoints[3]
                        };
                        break;
                    default: // Left
                        newBug.GetComponent<MothMovement>().pathPoints = new List<Transform>
                        {
                            bezierPoints[0],
                            bezierPoints[2],
                            bezierPoints[3]
                        };
                        break;
                }
                break;
        }
    }
}
