using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapCan : MonoBehaviour
{
    public Image Pointer; // untapped
    public Image PointerTap; // tapped
    public Image CanUntapped; // untapped can (when a droplet is missing)
    public Image CanTapped;
    public Image DropletFill;
    public Vector2 PointerStartPos;
    public Vector2 PointerEndPos;
    public float animationSpeed = 0.7f;
    private float timer = 0f;
    private bool PointerActive = true;    
    // Start is called before the first frame update
    void Start()
    {
        Pointer.rectTransform.anchoredPosition = PointerStartPos;
        PointerTap.rectTransform.anchoredPosition = PointerEndPos;
        PointerTap.enabled = false;
        CanUntapped.enabled = true;
        CanTapped.enabled = false;
        DropletFill.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;

        // switches images based on the animation speed
        if (timer >= animationSpeed)
        {
            // toggles between the two images
            PointerActive = !PointerActive;

            if (PointerActive)
            {
                Pointer.enabled = true;
                PointerTap.enabled = false;
                CanUntapped.enabled = true;
                CanTapped.enabled = false;
                DropletFill.enabled = false;
                Pointer.rectTransform.anchoredPosition = PointerStartPos;
            }

            else
            {
                Pointer.enabled = false;
                PointerTap.enabled = true;
                CanUntapped.enabled = false;
                CanTapped.enabled = true;
                DropletFill.enabled = true;
                PointerTap.rectTransform.anchoredPosition = PointerEndPos;
            }

            // resets the timer
            timer = 0f;
        }
    }
}
