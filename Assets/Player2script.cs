using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player2script : MonoBehaviour
{
    public float speed = 1.0f;
    public float distance = 2.0f;
    private Vector3 startPos;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = startPos + new Vector3(
    Mathf.Cos(Time.time * speed),
    Mathf.Sin(Time.time * speed), // è„â∫Ç…Ç‡ìÆÇ≠
    0
) * distance;
    }
}
