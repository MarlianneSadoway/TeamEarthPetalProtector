using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugSpawner : MonoBehaviour
{
    public GameObject bugPrefab; // Reference to the bug prefab
    public float spawnInterval = 1f; // Time between spawns
    public float spawnDuration = 150f; // Total duration of spawning 
    public float spawnDistance = 4f; // Distance from the camera to spawn bugs

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
        // Random Y position within a range
        float yPosition = Random.Range(-3.5f, 4.25f); // Adjust based on camera size

        // Randomly choose the left or right for X position
        float xPosition = (Random.Range(0, 2) == 0) ? -spawnDistance : spawnDistance;

        // Set the spawn position with X on the left or right, and random Y
        Vector3 spawnPosition = new Vector3(xPosition, yPosition, 0f);

        // Instantiate the bug at the chosen position
        Instantiate(bugPrefab, spawnPosition, Quaternion.identity);
    }
}

