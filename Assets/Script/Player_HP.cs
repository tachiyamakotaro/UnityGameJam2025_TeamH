using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̗̑�")]
    private int hp;
    private float invincibleTime;
    private int invincibleState = 0;
    private BoxCollider BoxCollider;
    //Start is called before the first frame update
    void Start()
    {
        BoxCollider = GetComponent<BoxCollider>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleState == 1)
        {
            invincibleTime += Time.deltaTime;
            BoxCollider.enabled = false; //���G��Ԃ̎��͓����蔻��𖳌��ɂ���
            if (invincibleTime >= 2.0f)
            {
                invincibleState = 0;
                invincibleTime = 0.0f;
                
            }
        }
        else if (invincibleState == 0)
        {
            BoxCollider.enabled = true; //���G��ԂłȂ����͓����蔻���L���ɂ���
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            //�Ԃ������I�u�W�F�N�g��Tag��Enemy_Bullet�Ƃ������O����������
        if (other.gameObject.tag == "Enemy_Bullet")        
        {
            hp--;
            invincibleState = 1;
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "Enemy")
        {
            hp--;
            invincibleState = 1;
        }
        
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
