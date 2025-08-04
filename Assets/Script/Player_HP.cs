using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_HP : MonoBehaviour
{
    [SerializeField, Header("�v���C���[�̗̑�")]
    private int hp;
    private float invincibleTime;
    private int invincibleState = 0;
    private BoxCollider boxCollider;
    //�_�ł̊Ԋu
    private float blinkInterval = 0.2f;
    //�_�ł̉�
    private int blinkCount = 8;
    ////�_�ł����邽�߂�MeshRenderer
    //// MeshRenderer[]�͔z��ŁA������MeshRenderer���i�[�ł���
    //// ���̃R�[�h�ł́A�v���C���[�I�u�W�F�N�g�Ƃ��̎q���I�u�W�F�N�g�ɂ���MeshRenderer��S�Ď擾����
    private MeshRenderer[] meshRenderers;
    //Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        //�����Ǝq���I�u�W�F�N�g��MeshRenderer���擾
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleState == 1)
        {
            if(invincibleTime<=0.0f)
            {
                //StartCoroutine(Blink())�̓R���[�`�����J�n���郁�\�b�h
                //�R���[�`����Unity�̓��ʂȃ��\�b�h�ŁA���Ԃ������ď������s�����Ƃ��ł���
                //StartCoroutine(Blink())��������Update()�̒��Ŗ��G��Ԃ̎��ɓ_�ł��鏈�������s����Ȃ�
                StartCoroutine(Blink()); //���G��Ԃ̎��͓_�ł�����
            }
            invincibleTime += Time.deltaTime;
            boxCollider.enabled = false; //���G��Ԃ̎��͓����蔻��𖳌��ɂ���
            if (invincibleTime >= 2.0f)
            {
                invincibleState = 0;
                invincibleTime = 0.0f;
                //���G���Ԃ�2�b�o�߂����疳�G��Ԃ���������
            }
        }
        else if (invincibleState == 0)
        {
            boxCollider.enabled = true; //���G��ԂłȂ����͓����蔻���L���ɂ���
            foreach (var blink in meshRenderers) blink.enabled = true; // ���b�V����\������
            invincibleTime = 0.0f;
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

    //���G��Ԃ̎��ɓ_�ł����鏈��
    private IEnumerator Blink()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // ���b�V���̕\���E��\����؂�ւ���
            //blinkInterval�̎��Ԃ��ƂɃ��b�V����\���E��\���ɂ���
            //blinkInterval��0.1�b

            // var �͌^�������Ō��߂���́B���̏ꍇ�� var �� MeshRenderer �^�̔z����w��
            // blink�͕ϐ����B���R�Ɍ��߂邱�Ƃ��o���܂��B(blink�ł͂Ȃ�A�Ȃǂł��ł���)
            // foreach�͔z��⃊�X�g�̗v�f��������o�����߂̍\��
            // ����̏ꍇunity����Player��player�̎q���I�u�W�F�N�g�ɂ���MeshRenderer��������o���Ă���

            yield return new WaitForSeconds(blinkInterval); //�w�肵�����ԑҋ@
            foreach(var blink in meshRenderers) blink.enabled = false; // ���b�V�����\���ɂ���

            yield return new WaitForSeconds(blinkInterval); //�w�肵�����ԑҋ@
            foreach (var blink in meshRenderers) blink.enabled = true; // ���b�V����\������
            
        }

    }

}
