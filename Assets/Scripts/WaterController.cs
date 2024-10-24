using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WaterController : MonoBehaviour
{
    public GameObject waterDrop; // Prefab for water drop
    public GameObject emptyDrop; // Prefab for empty drop
    private GameObject[] dropList; // List of waterDrop Instances
    public int numDrops; // Number of water drops
    public Transform location; // Location for left most water drop to appear
    public float interval; // Time between drops disappearing
    private float timer; // Countdown timer for water drops disappearing
    private int index; // Position in dropList
    public int newDrops;
    public GameObject gameOverUI; // When all water is lost, this is the game over popup
    public float delayBeforeMenu = 4f; // Delay to show Game Over before loading the MenuScene
    public WateringCan wateringCan;

    // Start is called before the first frame update
    void Start()
    {
        // Create waterDrop instances, set index and timer
        dropList = new GameObject[numDrops];
        index = numDrops-1;
        timer = interval;
        for (int i = 0; i < numDrops; i++)
        {
            // Display the drops vertically
            dropList[i] = Instantiate(waterDrop, new Vector3(location.position.x, (float)(location.position.y - (i*0.6)), location.position.z), Quaternion.identity, gameObject.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer is 0 and the index is not >= 0 Destroy a drop, decrement index, and reset timer
        if (timer <= 0 && index >=0)
        {
            // Replace waterDrop with emptyDrop
            ReplaceWithEmpty(index);
            index--;
            timer = interval; // Reset timer 
            if (index < 0) // All water is gone so game over 
            {
                GameOverLost gameOver = gameOverUI.GetComponent<GameOverLost>();
                gameOver.ShowGameOver();
                // Start the coroutine to delay before loading the menu scene
                StartCoroutine(GameOverTransition());
            }
        }
        // Decrement timer
        timer -= Time.deltaTime;
    }

     // Coroutine to handle the delay before loading the menu scene
     IEnumerator GameOverTransition()
    {
        // Wait for the delayBeforeMenu seconds
        yield return new WaitForSeconds(delayBeforeMenu);
        // Transition to the menu scene
        SceneManager.LoadScene("MenuScene");
    }

    public void ReplaceWithEmpty(int currentIndex)
    {
        // Store the position of the current waterDrop before destroying it
        Vector3 dropPosition = dropList[currentIndex].transform.position;
        // Destroy the current waterDrop
        Destroy(dropList[currentIndex]);
        // Instantiate the emptyDrop in the stored position
        dropList[currentIndex] = Instantiate(emptyDrop, dropPosition, Quaternion.identity, gameObject.transform);
        // Make the watering can shake to alert the player that the plant needs water
        if (wateringCan != null)
        {
            StartCoroutine(wateringCan.Shake());
        }
    }

    public void AddWater()
    {
    Debug.Log("Clicked!");
    for (int i = 0; i < newDrops; i++)
        {
            if (index >= numDrops-1) {break;}
            else
            {
                index++;
                // Store the position of the empty drop 
                Vector3 dropPosition = dropList[index].transform.position;
                // Replace the empty drop with a water drop
                Destroy(dropList[index]);
                dropList[index] = Instantiate(waterDrop, dropPosition, Quaternion.identity, gameObject.transform);
            }
        }
    }

    public int get_index()
    {
        return index;
    }
}
