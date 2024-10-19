using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class ChangeInstruction : MonoBehaviour
{
    public GameObject SwitchPage;
    public GameObject CurrentPage;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void tappedHandler(object sender, EventArgs e)
    {
        CurrentPage.SetActive(false);
        SwitchPage.SetActive(true);
    }
}
