using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHP : MonoBehaviour
{
    private int hp = 3;
    private MeshRenderer[] meshRenderers;
    private Collider[] colliders;
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

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player_Bullet")
        {
            hp -= 1;
            if (hp <= 0)
            {
                Destroy(gameObject);
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

        // �K�v������΃X�N���v�g�⓮�����~�߂鏈�����ǉ�
        // ��: this.enabled = false;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
