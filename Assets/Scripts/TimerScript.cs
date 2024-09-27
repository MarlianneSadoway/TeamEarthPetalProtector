using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class TimerScript : MonoBehaviour
{

    public float totalTime = 150; // Total time in seconds
    private float remainingTime;
    public bool timeRunning = false; // Trigger to start and stop timer
    public TMP_Text timeText; // UI Element for timer
    
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
            // Update TimerUI
            TimerUI(remainingTime);
        }
        else
        {
            // Set remainging time to zero so time isn't displayed as negative
            remainingTime = 0;
            // Disable Timer
            timeRunning = false;
            // Transition to Game over here
        }
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
