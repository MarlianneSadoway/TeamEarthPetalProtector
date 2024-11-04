using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;

public class WateringCan : MonoBehaviour
{
    private TapGesture gesture;
    public WaterController waterController;
    public Button button;
    public int interval = 10;
    private float timer;
    private bool decrement = false;
    public AudioSource waterSound;
    public Animated pulseAnimator; // makes the watering can pulse when drops are missing 
    public Image image;

    void Start()
    {
        timer = interval;
        GetComponent<TapGesture>().Tapped += tappedHandler;
        button.enabled = false;
    }

    void Update()
    {
        if (decrement)
        {
            timer -= Time.deltaTime;
            if (timer <= 0)
            {
                decrement = false;
                timer = interval;
                button.enabled = true;
            }
        }
        if (waterController.getIndex() < waterController.numDrops-1)
        {
            if (pulseAnimator != null)
            {
                pulseAnimator.enabled = true; // Enable pulsing
            }
            button.enabled = true;
            image.color = Color.green;
        }
        else
        {
            if (pulseAnimator != null)
            {
                pulseAnimator.enabled = false; // Disable pulsing
            }
            button.enabled = false;
            image.color = Color.yellow;
        }

    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        if(button.enabled)
        {
            button.enabled = false;
            decrement = true;
            waterController.SendMessage("AddWater");
            waterSound.Play();
        }
    }

}
