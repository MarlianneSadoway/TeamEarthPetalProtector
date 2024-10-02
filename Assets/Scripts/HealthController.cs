using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthController : MonoBehaviour
{
    public GameObject heart; // Prefab for heart icon 
    private GameObject[] heartList; // List of heart Instances
    public int numHearts; // Number of hearts
    public Transform location; // Location for left most heart to appear
    public float interval; // Time between hearts disappearing
    private int index; // Position in heartList

    // Start is called before the first frame update
    void Start()
    {
        // Create heart instances and set index 
        heartList = new GameObject[numHearts];
        index = numHearts - 1;
        for (int i = 0; i < numHearts; i++)
        {
            heartList[i] = Instantiate(heart, new Vector3((float)(location.position.x + i * 0.6), location.position.y, location.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
        
    }

    // Method to remove 1 heart from the health bar 
    public void RemoveHeart()
    {
        // Check if there are hearts left to remove
        if (index >= 0)
        {
            Destroy(heartList[index]); // Destroy the heart at the current index
            index--; // Set index to the next heart
        }
    }
}
