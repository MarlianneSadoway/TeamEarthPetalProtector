using System.Collections;
using System.Collections.Generic;
using TouchScript.Gestures;
using UnityEngine;

public class DestroyBugWithTap : MonoBehaviour
{
    private TapGesture gesture;
    public AudioSource bugDeath;
    public AudioClip[] squishSounds;
    public Sprite[] damagedBug; // damaged bug sprites
    public int fullHealth; // full health
    private int health;
    private SpriteRenderer spriteRenderer;

    [Header("Click Animation Settings")]
    public float growScale = 1.2f; // Scale multiplier for the "clicked" effect
    public float growDuration = 0.05f; // Duration of the "clicked" effect
    private Color originalColor;

    // Start is called before the first frame update
    void Start()
    {
        gesture = GetComponent<TapGesture>();
        gesture.Tapped += tappedHandler;
        health = fullHealth; // bug's initial health is full health
        spriteRenderer = GetComponent<SpriteRenderer>();

        if (spriteRenderer != null)
        {
            originalColor = spriteRenderer.color;
        }
    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        // Play click animation immediately on every tap
        StartCoroutine(PlayClickAnimation());

        // Reduce health and play sound
        health--;
        AudioClip randomClip = squishSounds[Random.Range(0, squishSounds.Length)];
        bugDeath.PlayOneShot(randomClip, 0.2f);

        StartCoroutine(BugFlashWhenHit());
        
        // Change sprite if health is not depleted
        if (health > 0)
        {
            int spriteIndex = Mathf.Clamp(fullHealth - health - 1, 0, damagedBug.Length - 1);
            spriteRenderer.sprite = damagedBug[spriteIndex];
        }
        else
        {
            // Destroy the bug when health is depleted
            Invoke("killBug", 0.15f);
        }
    }

    // Coroutine to handle the click animation effect
    private IEnumerator PlayClickAnimation()
    {
        Vector3 originalScale = transform.localScale;
        Vector3 targetScale = originalScale * growScale;

        // Scale up
        float timer = 0f;
        while (timer < growDuration)
        {
            transform.localScale = Vector3.Lerp(originalScale, targetScale, timer / growDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        // Scale back down
        timer = 0f;
        while (timer < growDuration)
        {
            transform.localScale = Vector3.Lerp(targetScale, originalScale, timer / growDuration);
            timer += Time.deltaTime;
            yield return null;
        }

        transform.localScale = originalScale; // Ensure scale resets back to original
    }

    // Coroutine to make the bug flash when hit
    private IEnumerator BugFlashWhenHit()
    {
        // Change color to red
        spriteRenderer.color = Color.red;
        
        yield return new WaitForSeconds(0.2f);
        
        // Change back to original color
        spriteRenderer.color = originalColor;
    }

    private void killBug()
    {
        Destroy(gameObject);
    }
}
