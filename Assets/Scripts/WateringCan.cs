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

    public float shakeDuration = 0.2f; // How long it shakes for
    public float shakeTilt = 0.1f; // Degrees of tilt for the shaking 
    public float shakeSpeed = 0.2f; // The delay between each tilt
    private Vector3 initialPosition; // The original position of the watering can


    void Start()
    {
        timer = interval;
        GetComponent<TapGesture>().Tapped += tappedHandler;
        button.enabled = false;
        initialPosition = transform.localPosition; // Get the initial position and store it 
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
        if (waterController.get_index() < waterController.numDrops-1)
        {
            button.enabled = true;
        }
        else
        {
            button.enabled = false;
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

    // Watering can shakes when the plant needs water (water drop disappears)
    public IEnumerator Shake()
    {
        float elapsedTime = 0f;
        bool isTiltingRight = true; // To alternate between tilting and initial position

        while (elapsedTime < shakeDuration)
        {
            if (isTiltingRight)
            {
                // Rotate clockwise around z axis
                transform.localRotation = Quaternion.Euler(0, 0, -shakeTilt);
            }
            else
            {
                // Put back to the initial position (no tilt)
                transform.localRotation = Quaternion.Euler(0, 0, 0);
            }
            // Update tilting to false 
            isTiltingRight = !isTiltingRight;
            // Delay between each tilt
            yield return new WaitForSeconds(shakeSpeed);
            // Update elapsed time
            elapsedTime += shakeSpeed;
            
        }
        // Shaking done so put the watering can back to its initial position
        transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

}
