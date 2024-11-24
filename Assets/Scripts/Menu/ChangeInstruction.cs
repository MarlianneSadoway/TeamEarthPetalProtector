using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class ChangeInstruction : MonoBehaviour
{
    public GameObject SwitchPage;
    public GameObject CurrentPage;
    public GameObject Instruct;
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

    // Update is called once per frame
    void Update()
    {
        
    }
    
    private void tappedHandler(object sender, EventArgs e)
    {
        soundEffect.Play();
        Invoke("nextMenu", (float)0.25);
        restartAFKTimer();
    }

    private void nextMenu()
    {
        CurrentPage.SetActive(false);
        SwitchPage.SetActive(true);
    }
    private void startAFKTimer()
    {
        closeOverlayCoroutine = StartCoroutine(closeOverlay());
    }

    private void restartAFKTimer()
    {
        if (!gameObject.activeInHierarchy)
        {
            Debug.LogWarning("Cannot restart AFK timer because the GameObject is inactive.");
            return;
        }
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
        SecondInstruct.SetActive(false);
        ThirdInstruct.SetActive(false);
        FourthInstruct.SetActive(false);
        FifthInstruct.SetActive(false);
        SixthInstruct.SetActive(false);
    }
}
