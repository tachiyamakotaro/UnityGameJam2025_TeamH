using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab; // �G�l�~�[�̃v���n�u
    private float spawnInterval=3.0f; // �G�̃X�|�[���Ԋu
    private float spawnTimer=0.0f; // �X�|�[���^�C�}�[
    private int maxEnemyCount = 5; // �ő吶����

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // �^�C�}�[���X�V

        int EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // ���݂̓G�̐����擾

        if (spawnTimer > spawnInterval)
        {
            if (EnemyCount < maxEnemyCount) // �ő吶�����ȉ��Ȃ�G�𐶐�
            {
                //enemy���C���X�^���X������(��������)
                GameObject enemy = Instantiate(EnemyPrefab);
                // �����_���Ȉʒu�ɔz�u
                enemy.transform.position = new Vector3(Random.Range(0.0f, 6.0f), Random.Range(-2.0f, 3.0f), 0.0f);
                spawnTimer = 0.0f; // �^�C�}�[�����Z�b�g
            }
            spawnTimer = 0.0f; // �^�C�}�[�����Z�b�g
        }
    }
}
