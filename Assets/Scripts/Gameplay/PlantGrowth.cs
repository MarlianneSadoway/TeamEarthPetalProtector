using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantGrowth : MonoBehaviour
{

    public float growthSpeed = 0.027f; // how fast the plant grows during the game
    public float maxHeight = 4.0f; // the maximum height of the plant 


    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        // Calculate the new size of the plant using the time that has elapsed so far so that the plant grows over time 
        float newSize = transform.localScale.y + growthSpeed * Time.deltaTime;

        // Check if the plant is the maximum size
        if (newSize > maxHeight)
        {
            newSize = maxHeight; // don't grow plant if plant is the maximum size 
        }

        // Change the size of the plant in the Y direction while keeping x and z the same 
        transform.localScale = new Vector3(transform.localScale.x, newSize, transform.localScale.z);

    }
}








