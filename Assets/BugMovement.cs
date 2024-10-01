using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BugMovement : MonoBehaviour
{
    public float speed = 2.5f; // Speed of the bug
    private Vector2 direction; // Direction to move

    // Start is called before the first frame update
    void Start()
    {
        // Set direction randomly to left or right
        direction = Random.Range(0, 2) == 0 ? Vector2.right : Vector2.left;
    }

    // Update is called once per frame
    void Update()
    {
        // Move the bug
        transform.Translate(direction * speed * Time.deltaTime);

    }
}
