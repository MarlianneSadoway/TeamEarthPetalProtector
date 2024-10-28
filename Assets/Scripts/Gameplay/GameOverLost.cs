using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameOverLost : MonoBehaviour
{
    public GameObject gameOverUI; // The popup overlay to show game is lost

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameOver()
    {
        gameOverUI.SetActive(true); // Activate the Game Over UI
    }
}
