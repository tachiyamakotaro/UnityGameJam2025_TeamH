using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの体力")]
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
            BoxCollider.enabled = false; //無敵状態の時は当たり判定を無効にする
            if (invincibleTime >= 2.0f)
            {
                invincibleState = 0;
                invincibleTime = 0.0f;
                
            }
        }
        else if (invincibleState == 0)
        {
            BoxCollider.enabled = true; //無敵状態でない時は当たり判定を有効にする
        }
    }

    private void OnTriggerEnter(Collider other)
    {
            //ぶつかったオブジェクトのTagにEnemy_Bulletという名前があったら
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
