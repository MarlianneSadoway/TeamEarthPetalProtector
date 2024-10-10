using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StemGrowth : MonoBehaviour
{
    public float growthDuration = 150f;  // Duration of growth in seconds (2.5 minutes)
    public float endPositionY = 0f;
    private Vector3 initialPosition;
    private Vector3 targetPosition;
    private float elapsedTime = 0f;

    void Start()
    {
        initialPosition = transform.position; // Only top part of stem showing
        targetPosition = new Vector3(initialPosition.x, endPositionY, initialPosition.z); // Base can't get higher than y=0
    }

    void Update()
    {
        elapsedTime += Time.deltaTime; // Update time passed so far

        // Calculate the fraction of time passed relative to the total growth duration
        float t = Mathf.Clamp01(elapsedTime / growthDuration);

        // Move the stem upwards gradually to target position
        transform.position = Vector3.Lerp(initialPosition, targetPosition, t);

        if (t >= 1.0f)
        {
            enabled = false; // Stop growing once reached the target position
        }
    }
}