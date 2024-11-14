using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameIndex : MonoBehaviour
{
    // Index to keep track of assigned screen
    public int index;
    // Global game controller
    public GameController gameController;

    // Function to swap from menu to easy game
    public void swapGameEasy()
    {
        gameController.menuToEasy(index);
    }

    // Function to swap from menu to hard game
    public void swapGameHard()
    {
        gameController.menuToHard(index);
    }
    // Function to swap from game to menu
    public void swapMenu()
    {
        gameController.gameToMenu(index);
    }
}
