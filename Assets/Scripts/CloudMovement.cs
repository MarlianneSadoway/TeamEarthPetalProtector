using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudMovement : MonoBehaviour
{

    public float speed = 0.2f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.right * speed * Time.deltaTime);

        // loop clouds
        if (transform.position.x > 10)
        {
            transform.position = new Vector3(-10, transform.position.y, transform.position.z);
        }
    }
}
