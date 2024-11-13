using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TouchScript.Gestures;

public class BackToMenu : MonoBehaviour
{
    private AudioSource soundEffect;
    public GameIndex gameIndex;
    // Start is called before the first frame update
    void Start()
    {
        soundEffect = GetComponent<AudioSource>();
        GetComponent<TapGesture>().Tapped += tappedHandler;
    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        soundEffect.Play();
        gameIndex.Invoke("swapMenu", 0.25f);
    }

}
