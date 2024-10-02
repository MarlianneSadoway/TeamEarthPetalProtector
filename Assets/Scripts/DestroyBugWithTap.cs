using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class DestroyBugWithTap : MonoBehaviour
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

    private void tappedHandler(object sender, System.EventArgs e)
    {
        Destroy(gameObject); // Destroy the bug when tapped
    }
}
