using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayEasyScene : MonoBehaviour
{
    public GameObject SelectDiff;
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
        SelectDiff.SetActive(false); // deactivates overlay before loading next scene
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single); // loads MainScene when EASY is tapped
    }
}
