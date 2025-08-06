using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField, Header("�e��")]
    public float shotSpeed;
    //private float shotInterval;
    private float time;
    private Rigidbody bulletRb; // Rigidbody�̕ϐ���錾
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
        bulletRb = bulletPrefab.GetComponent<Rigidbody>(); // Rigidbody�R���|�[�l���g���擾
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.5f)
        {
            

                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

            //bulletRb.AddForce(transform.right * shotSpeed);
            bulletRb.AddForce(-transform.right * shotSpeed);

                time = 0.0f;
                Destroy(bullet, 3.0f);
           
        }
    }
}
