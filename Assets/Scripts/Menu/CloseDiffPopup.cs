using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class CloseDiffPopup : MonoBehaviour
{

    public GameObject SelectDifficulty;
    private AudioSource soundEffect;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void tappedHandler(object sender, EventArgs e)
    {
        soundEffect.Play();
        Invoke("closePopup", (float)0.25);
    }

    private void closePopup()
    {
        SelectDifficulty.SetActive(false);
    }
}
