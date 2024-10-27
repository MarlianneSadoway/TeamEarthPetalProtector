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

    // Start is called before the first frame update
    void Start()
    {
        GetComponent<TapGesture>().Tapped += tappedHandler;
        health = fullHealth; // bug's initial health is full health
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void tappedHandler(object sender, System.EventArgs e)
    {
        health--;

        AudioClip randomClip = squishSounds[Random.Range(0, squishSounds.Length)];
        bugDeath.PlayOneShot(randomClip, 0.2f);
        
        if (health > 0)
        {
            // change sprite to damaged
            int spriteIndex = Mathf.Clamp(fullHealth - health - 1, 0, damagedBug.Length - 1);
            spriteRenderer.sprite = damagedBug[spriteIndex];
        }
        else
        {
            // Destroy the bug when tapped at last health
            Invoke("killBug", 0.15f);
        }
    }

    private void killBug()
    {
        Destroy(gameObject);
    }
}
