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
    public GameObject gameOverUI; // When all hearts are lost, this is the game over popup
    public float delayBeforeMenu = 4f; // Delay to show Game Over before loading the MenuScene
    public AudioSource heartPop;
    public GameObject plant; 
    public GameIndex gameIndex;
    private SpriteRenderer plantSprite;
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        // Create heart instances and set index 
        heartList = new GameObject[numHearts];
        index = numHearts - 1;
        for (int i = 0; i < numHearts; i++)
        {
            // Display the hearts vertically
            heartList[i] = Instantiate(heart, new Vector3(location.position.x, (float)(location.position.y - (i * 0.6)), location.position.z), Quaternion.identity, gameObject.transform);
        }

        //plant = GameObject.FindWithTag("Plant");
        plantSprite = plant.GetComponent<SpriteRenderer>();
        // Get plant's original color
        if (plantSprite != null)
        {
            originalColor = plantSprite.color;
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
            heartPop.Play();
            StartCoroutine(PlantFlashWhenHit()); // Make the plant flash red
            GameObject heartToRemove = heartList[index];
            heartToRemove.AddComponent<HeartFall>(); // Makes the heart fall downwards off the screen 
            index--; // Set index to the next heart
        }

        // If there are no hearts left, show Game Over and restart the game 
        if (index < 0)
        {
            GameOverLost gameOver = gameOverUI.GetComponent<GameOverLost>();
            gameOver.ShowGameOver();

            // Start the coroutine to delay before loading the menu scene
            StartCoroutine(GameOverTransition());
        }
    }

    IEnumerator PlantFlashWhenHit() {
        // Get sprites of the parent and children
        SpriteRenderer[] allSprites = plant.GetComponentsInChildren<SpriteRenderer>();

        // Change plant's sprite color to red
        foreach (SpriteRenderer sprite in allSprites)
        {
            sprite.material.color = Color.red;
        }

        yield return new WaitForSeconds(0.2f);

        // Revert the plant color back to its original color
        foreach (SpriteRenderer sprite in allSprites)
        {
            sprite.material.color = originalColor;
        }
        
    }

    // Coroutine to handle the delay before loading the menu scene
    IEnumerator GameOverTransition()
    {
        // Wait for the delayBeforeMenu seconds
        yield return new WaitForSeconds(delayBeforeMenu);

        // Transition to the menu scene
        gameIndex.swapMenu();
    }
}
