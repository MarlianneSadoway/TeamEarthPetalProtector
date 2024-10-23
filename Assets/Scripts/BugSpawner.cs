using System.Collections;
using System.Collections.Generic;
using UnityEditor.UI;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject beetlePrefab; // Reference to the Beetle prefab
    public GameObject flyPrefab; // Reference to the Fly prefab
    public GameObject waspPrefab; // Reference to the Wasp prefab
    public GameObject mothPrefab; // Reference to the Moth prefab

    public float spawnInterval = 8f; // Time between spawns
    public float spawnDuration = 150f; // Total duration of spawning 
    public float spawnDistance = 2f; // Distance from the camera to spawn bugs

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

        // Random X position between -2.5 and 1
        float xPosition = Random.Range(-1.5f, 1f); 

        // Set the spawn position with X on the left or right, and random Y
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

        // Randomly choose which bug prefab to spawn (0 = beetle, 1 = fly, 2 = wasp, 3 = moth)
        int bugType = Random.Range(0, 4);
        GameObject selectedBugPrefab = (bugType == 0) ? beetlePrefab : (bugType == 1) ? flyPrefab : (bugType == 2) ? waspPrefab : mothPrefab; // Moth

        // Instantiate the selected bug at the chosen position
        Instantiate(selectedBugPrefab, spawnPosition, Quaternion.identity, gameObject.transform);
    }
}
