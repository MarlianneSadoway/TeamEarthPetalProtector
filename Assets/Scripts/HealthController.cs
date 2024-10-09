using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class HealthController : MonoBehaviour
{
    public GameObject heart; // Prefab for heart icon 
    private GameObject[] heartList; // List of heart Instances
    public int numHearts; // Number of hearts
    public Transform location; // Location for top most heart to appear
    private int index; // Position in heartList

    // Start is called before the first frame update
    void Start()
    {
        // Create heart instances and set index 
        heartList = new GameObject[numHearts];
        index = numHearts - 1;
        for (int i = 0; i < numHearts; i++)
        {
            // Display the hearts vertically
            heartList[i] = Instantiate(heart, new Vector3(location.position.x, (float)(location.position.y - (i * 0.6)), location.position.z), Quaternion.identity);
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
            GameObject heartToRemove = heartList[index];
            heartToRemove.AddComponent<HeartFall>(); // Makes the heart fall downwards off the screen 
            index--; // Set index to the next heart
        }

        // If there are no hearts left, restart the game 
        if (index < 0)
        {
            // Transition to Game over here by going back to the menu 
            SceneManager.LoadScene("MenuScene");
        }
    }
}
