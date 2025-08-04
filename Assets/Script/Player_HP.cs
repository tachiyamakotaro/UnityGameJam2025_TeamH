using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player_HP : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの体力")]
    private int hp;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        //ぶつかったオブジェクトのTagにEnemy_Bulletという名前があったら
        if (other.gameObject.tag == "Enemy_Bullet")
        {
            hp --;
            
            Destroy(other.gameObject);
        }
        if(other.gameObject.tag=="Enemy")
        {
            hp--;
        }
        if (hp <= 0)
        {
            Destroy(gameObject);
        }
    }
}
