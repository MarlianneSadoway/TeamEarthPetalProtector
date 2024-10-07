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
        if(button.enabled = true)
        {
            button.enabled = false;
            decrement = true;
            waterController.SendMessage("AddWater");
        }
    }
}
