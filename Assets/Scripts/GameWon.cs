using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameWon : MonoBehaviour
{

    public GameObject gameWonUI; // The popup overlay to show game is won 

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void ShowGameWon()
    {
        gameWonUI.SetActive(true); // Activate the Game Won UI
    }
}
