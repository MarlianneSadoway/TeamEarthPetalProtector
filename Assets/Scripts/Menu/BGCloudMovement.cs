using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGCloudMovement : MonoBehaviour
{
    public float speed = 0.05f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // loop clouds
        if (transform.localPosition.x > 16.5)
        {
            transform.localPosition = new Vector3(-15, transform.localPosition.y, transform.localPosition.z);
        }
    }
}
