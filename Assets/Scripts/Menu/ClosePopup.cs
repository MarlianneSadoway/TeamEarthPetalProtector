using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class ClosePopup : MonoBehaviour
{
    public GameObject Instruct;
    public GameObject SecondInstruct;
    public GameObject ThirdInstruct;
    public GameObject FourthInstruct;
    public GameObject FifthInstruct;
    public GameObject SixthInstruct;
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
        Instruct.SetActive(false);
        SecondInstruct.SetActive(false);
        ThirdInstruct.SetActive(false);
        FourthInstruct.SetActive(false);
        FifthInstruct.SetActive(false);
        SixthInstruct.SetActive(false);
    }
}
