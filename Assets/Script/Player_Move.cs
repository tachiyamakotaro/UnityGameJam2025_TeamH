using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    Rigidbody rb;
    float speed = 3.0f;
    // Start is called before the first frame update
    void Start()
    {
        rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.W))
        {
            rb.velocity= transform.up*speed;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            rb.velocity = -transform.up * speed;
        }
        if (Input.GetKeyDown(KeyCode.A))
        {
            rb.velocity = -transform.right * speed;
        }
        if(Input.GetKeyDown(KeyCode.D))
        {
            rb.velocity = transform.right * speed;
        }
    }
}
