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
        // 自身と子オブジェクトすべての MeshRenderer を取得
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
        // コライダーも無効にする用
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
        // メッシュを非表示にする
        foreach (var mr in meshRenderers)
        {
            mr.enabled = false;
        }

        // コライダーも無効化
        foreach (var col in colliders)
        {
            col.enabled = false;
        }

        // 必要があればスクリプトや動きを止める処理も追加
        // 例: this.enabled = false;
    }
    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
   
}
