using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject EnemyPrefab; // エネミーのプレハブ
    private float spawnInterval=3.0f; // 敵のスポーン間隔
    private float spawnTimer=0.0f; // スポーンタイマー
    private int maxEnemyCount = 5; // 最大生成数

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        spawnTimer += Time.deltaTime; // タイマーを更新

        int EnemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length; // 現在の敵の数を取得

        if (spawnTimer > spawnInterval)
        {
            if (EnemyCount < maxEnemyCount) // 最大生成数以下なら敵を生成
            {
                //enemyをインスタンス化する(生成する)
                GameObject enemy = Instantiate(EnemyPrefab);
                // ランダムな位置に配置
                enemy.transform.position = new Vector3(Random.Range(0.0f, 6.0f), Random.Range(-2.0f, 3.0f), 0.0f);
                spawnTimer = 0.0f; // タイマーをリセット
            }
            spawnTimer = 0.0f; // タイマーをリセット
        }
    }
}
