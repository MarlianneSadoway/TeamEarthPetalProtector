using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class TimerScript : MonoBehaviour
{

    public float totalTime = 90; // Total time in seconds
    private float remainingTime;
    public bool timeRunning = false; // Trigger to start and stop timer
    public TMP_Text timeText; // UI Element for timer
    public GameObject gameWonUI; // Popup/overlay to show game won msg to player 
    public float delayBeforeMenu = 4f; // Delay to show Game Won before loading the MenuScene
    public GameIndex gameIndex;

    // Start is called before the first frame update
    void Start()
    {
        // Start Timer
        remainingTime = totalTime;
        timeRunning = true;
    }

    // Update is called once per frame
    void Update()
    {
        
        if(timeRunning)
        {
            // Decrement time if the timer is running
            remainingTime -= Time.deltaTime;

            // Check if time is up
            if (remainingTime <= 0)
            {
                // Set remainging time to zero so time isn't displayed as negative
                remainingTime = 0;
                // Disable Timer
                timeRunning = false;


                GameWon gameWon = gameWonUI.GetComponent<GameWon>();
                gameWon.ShowGameWon();

                // Start the coroutine to wait before loading the menu scene
                StartCoroutine(GameWonTransition());
            }

            // Update TimerUI
            TimerUI(remainingTime);

        }

    }

    // Coroutine to handle the delay before transitioning to the menu scene
    IEnumerator GameWonTransition()
    {
        // Wait for the delayBeforeMenu seconds
        yield return new WaitForSeconds(delayBeforeMenu);

        // Transition to the menu scene
        //SceneManager.LoadScene("MenuScene");
        gameIndex.Invoke("swapMenu", 0.25f);
    }

    void TimerUI(float time)
    {
        // Get the minute and seconds of the time
        float min = Mathf.FloorToInt(time/60);
        float sec = Mathf.FloorToInt(time%60);
        // Set UI to the time
        timeText.text = string.Format("{0:00}:{1:00}", min, sec);
    }
}
