using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TapAnimation : MonoBehaviour
{
    public Image Pointer; // untapped
    public Image PointerTap; // tapped
    public Image BugImage; // image with bug alive
    public Image BugTapped; // image with bug deleted
    public float animationSpeed = 0.7f;

    public Vector2 PointerStartPos;
    public Vector2 PointerEndPos;

    private float timer = 0f;
    private bool PointerActive = true;

    // starts off with the cursor in the UNTAPPED state, and the bug displayed
    void Start()
    {
        Pointer.rectTransform.anchoredPosition = PointerStartPos;
        PointerTap.rectTransform.anchoredPosition = PointerEndPos;
        PointerTap.enabled = false;
        BugImage.enabled = true;
        BugTapped.enabled = false;
    }

    // loops the cursor being tapped + bug disappearing
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
                BugImage.enabled = true;
                BugTapped.enabled = false;
                Pointer.rectTransform.anchoredPosition = PointerStartPos;
            }

            else
            {
                Pointer.enabled = false;
                PointerTap.enabled = true;
                BugImage.enabled = false;
                BugTapped.enabled = true;
                PointerTap.rectTransform.anchoredPosition = PointerEndPos;
            }

            // resets the timer
            timer = 0f;
        }
    }
}
