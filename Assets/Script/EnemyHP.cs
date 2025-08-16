using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class EnemyHP : MonoBehaviour
{
    private int hp = 3;
    private MeshRenderer[] meshRenderers;
    private Collider[] colliders;

    [SerializeField] private AudioClip DamegeClip; // �_���[�W����Inspector����Z�b�g
    // Start is called before the first frame update
    void Start()
    {
        // ���g�Ǝq�I�u�W�F�N�g���ׂĂ� MeshRenderer ���擾
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        // �R���C�_�[�������ɂ���p
        colliders = GetComponentsInChildren<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        //OnBecameInvisible();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player_Bullet")
        {
            hp -= 1;
            AudioManager.instance.PlaySE(DamegeClip); // �G�̃_���[�W����炷
            if (hp <= 0)
            {
                //SceneManager.LoadScene("GameClear"); //�̗͂�0�ɂȂ�����Q�[���I�[�o�[��ʂɑJ��
                OnDeath();
            }
            Destroy(other.gameObject);
        }
    }
    private void OnDeath()
    {
       

        // ���b�V�����\���ɂ���
        foreach (var mr in meshRenderers)
        {
            mr.enabled = false;
        }

        // �R���C�_�[��������
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        Destroy(gameObject); // 1�b��ɃI�u�W�F�N�g���폜
        // �K�v������΃X�N���v�g�⓮�����~�߂鏈�����ǉ�
        // ��: this.enabled = false;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
