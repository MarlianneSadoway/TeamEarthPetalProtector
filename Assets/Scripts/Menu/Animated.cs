using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// gives the pulsing effect to a game object

public class Animated : MonoBehaviour
{
    public float pulseSpeed = 2.3f;   // speed of the pulsing effect
    public float maxScale = 1.0f;   // maximum scale size
    public float minScale = 0.85f;   // minimum scale size

    private Vector3 initialScale;

    // Start is called before the first frame update
    void Start()
    {
        initialScale = transform.localScale;  // stores the original scale
    }

    void Update()
    {
        float scale = Mathf.Lerp(minScale, maxScale, (Mathf.Sin(Time.time * pulseSpeed) + 1) / 2);
        transform.localScale = initialScale * scale;
    }
}
