using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.UI;

public class WateringCan : MonoBehaviour
{

    private TapGesture gesture;
    public WaterController waterController;
    
    void Start()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }
    /*public void OnClick()
    {
        waterController.SendMessage("AddWater");
    }*/
    private void tappedHandler(object sender, System.EventArgs e)
    {
        waterController.SendMessage("AddWater");
    }
}
