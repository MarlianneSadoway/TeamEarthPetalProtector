using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class DestroyBugWithTap : MonoBehaviour
{

    private TapGesture gesture;
    public AudioSource bugDeath;
    public AudioClip[] squishSounds;

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        AudioClip randomClip = squishSounds[Random.Range(0, squishSounds.Length)];
        bugDeath.PlayOneShot(randomClip, 0.2f);
        Debug.Log(randomClip);
        Invoke("killBug", 0.15f);// Destroy the bug when tapped
    }

    private void killBug()
    {
        Destroy(gameObject);
    }
}
