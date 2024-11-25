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
    public float delayBeforeClose = 40f; // for AFK timer 
    private Coroutine closeOverlayCoroutine;

    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        GetComponent<TapGesture>().Tapped += tappedHandler;
        startAFKTimer();
    }

    private void tappedHandler(object sender, EventArgs e)
    {
        soundEffect.Play();
        restartAFKTimer();
        Invoke("nextMenu", 0.25f);
    }

    private void nextMenu()
    {
        Instruct.SetActive(true);
        FirstInstruct.SetActive(true);
        SecondInstruct.SetActive(false);
        ThirdInstruct.SetActive(false);
        FourthInstruct.SetActive(false);
        FifthInstruct.SetActive(false);
        SixthInstruct.SetActive(false);
    }

    private void startAFKTimer() {
        closeOverlayCoroutine = StartCoroutine(closeOverlay());
    }

    private void restartAFKTimer()
    {
        if (closeOverlayCoroutine != null)
        {
            StopCoroutine(closeOverlayCoroutine);
        }
        startAFKTimer();
    }

    IEnumerator closeOverlay()
    {
        yield return new WaitForSeconds(delayBeforeClose);
        Debug.Log("40 seconds are up!");
        CloseInstructions();
     }

    private void CloseInstructions()
    {
        Instruct.SetActive(false);
        FirstInstruct.SetActive(false);
    }
}
