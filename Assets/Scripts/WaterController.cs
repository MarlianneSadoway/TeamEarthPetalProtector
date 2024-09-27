using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterController : MonoBehaviour
{
    public GameObject waterDrop; // Prefab for water drop
    private GameObject[] dropList; // List of waterDrop Instances
    public int numDrops; // Number of water drops
    public Transform location; // Location for left most water drop to appear
    public float interval; // Time between drops disappearing
    private float timer; // Countdown timer for water drops disappearing
    private int index; // Position in dropList
    // Start is called before the first frame update
    void Start()
    {
        // Create waterDrop instances, set index and timer
        dropList = new GameObject[numDrops];
        index = numDrops-1;
        timer = interval;
        for (int i = 0; i < numDrops; i++)
        {
            dropList[i] = Instantiate(waterDrop, new Vector3((float)(location.position.x + i*0.6),location.position.y,location.position.z), Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // If the timer is 0 and the index is not >= 0 Destroy a drop, decrement index, and reset timer
        if (timer <= 0 && index >=0)
        {
            Destroy(dropList[index]);
            index--;
            timer = interval;
        }
        // Decrement timer
        timer -= Time.deltaTime;
    }
}
