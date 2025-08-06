using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.FullSerializer;
using UnityEngine;

public class Player_Move : MonoBehaviour
{
    //Rigidbody rb;
   [SerializeField,Header("移動速度")] 
    private float speed;

    // Start is called before the first frame update
    void Start()
    {
        //rb=GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(Vector3.up * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(Vector3.down * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.Translate(Vector3.back * speed * Time.deltaTime);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Translate(Vector3.forward * speed * Time.deltaTime);
        }
        //プレイヤーの移動制限。画面外に移動しなくなる
        float X = transform.position.x;
        float Y = transform.position.y;
        X =Mathf.Clamp(X, -8.0f, 8.0f);
        Y = Mathf.Clamp(Y, -4.0f, 6.0f);
        transform.position = new Vector3(X,Y, transform.position.z);
       
       // transform.position=new Vector3(transform.position.x,Y,transform.position.z);
    }
}
