using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab; // �G�l�~�[�̃v���n�u
    private float spawnInterval=5.0f; // �G�̃X�|�[���Ԋu
    private float spawnTimer=0.0f; // �X�|�[���^�C�}�[

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // �^�C�}�[���X�V
        if (spawnTimer > spawnInterval)
        {
            //enemy���C���X�^���X������(��������)
            GameObject enemy=Instantiate(EnemyPrefab);
            // �����_���Ȉʒu�ɔz�u
            enemy.transform.position=new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f),0.0f); 
            spawnTimer = 0.0f; // �^�C�}�[�����Z�b�g
        }
    }
}
