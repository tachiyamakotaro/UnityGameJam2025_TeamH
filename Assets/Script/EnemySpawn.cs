using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab; // エネミーのプレハブ
    private float spawnInterval=5.0f; // 敵のスポーン間隔
    private float spawnTimer=0.0f; // スポーンタイマー

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // タイマーを更新
        if (spawnTimer > spawnInterval)
        {
            //enemyをインスタンス化する(生成する)
            GameObject enemy=Instantiate(EnemyPrefab);
            // ランダムな位置に配置
            enemy.transform.position=new Vector3(Random.Range(-10.0f, 10.0f),Random.Range(-10.0f, 10.0f),0.0f); 
            spawnTimer = 0.0f; // タイマーをリセット
        }
    }
}
