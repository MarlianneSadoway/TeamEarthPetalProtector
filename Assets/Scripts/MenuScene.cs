using System;
using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScene : MonoBehaviour
{
    private TapGesture gesture;
    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tappedHandler(object sender, EventArgs e) {
        SceneManager.LoadScene("MainScene", LoadSceneMode.Single); // Loads MainScene when PLAY is tapped
    }
}
