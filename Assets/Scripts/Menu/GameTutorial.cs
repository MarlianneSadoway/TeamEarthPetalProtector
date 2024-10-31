using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class GameTutorial : MonoBehaviour
{
    public GameObject Instruct;
    public GameObject FirstInstruct;
    public GameObject SecondInstruct;
    public GameObject ThirdInstruct;
    public GameObject FourthInstruct;
    public GameObject FifthInstruct;
    public GameObject SixthInstruct;
    private AudioSource soundEffect;
    public float delayBeforeClose = 60f;

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
        Invoke("nextMenu", (float)0.25);
    }

    private void nextMenu()
    {
        Instruct.SetActive(true);
        FirstInstruct.SetActive(true);
        // coroutine to start a timer for the instructions to close if left open for 45 seconds
        StartCoroutine(closeOverlay(delayBeforeClose));
    }

    IEnumerator closeOverlay(float duration)
    {
        yield return new WaitForSeconds(duration);
        Instruct.SetActive(false);
        FirstInstruct.SetActive(false);
        SecondInstruct.SetActive(false);
        ThirdInstruct.SetActive(false);
        FourthInstruct.SetActive(false);
        FifthInstruct.SetActive(false);
        SixthInstruct.SetActive(false);
    }
}
