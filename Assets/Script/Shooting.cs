using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    public GameObject bulletPrefab;
    [SerializeField,Header("�e��")]
    public float shotSpeed;
    //private float shotInterval;
    private float time;
    private AudioSource audioSource;  //AudioSource�̕ϐ���錾
    
    // Start is called before the first frame update
    void Start()
    {
        time = 1.0f;
        audioSource = GetComponent<AudioSource>(); //AudioSource�R���|�[�l���g���擾
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
        if (time >= 0.2f)
        {
            if (Input.GetKey(KeyCode.Mouse0))
            {
                // �}�E�X�̍��{�^���������ꂽ�Ƃ��ɉ����Đ�

                audioSource.PlayOneShot(audioSource.clip);
               
                GameObject bullet = (GameObject)Instantiate(bulletPrefab, transform.position, Quaternion.Euler(transform.parent.eulerAngles.x, transform.parent.eulerAngles.y, 0));
                Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

                bulletRb.AddForce(transform.right * shotSpeed);

                time = 0.0f;
                Destroy(bullet, 1.0f);
            }
        }
    }
}
