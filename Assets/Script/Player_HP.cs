using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player_HP : MonoBehaviour
{
    [SerializeField, Header("プレイヤーの体力")]
    private int hp;
    private float invincibleTime;
    private int invincibleState = 0;
    private BoxCollider boxCollider;
    //点滅の間隔
    private float blinkInterval = 0.2f;
    //点滅の回数
    private int blinkCount = 8;
    ////点滅させるためのMeshRenderer
    //// MeshRenderer[]は配列で、複数のMeshRendererを格納できる
    //// このコードでは、プレイヤーオブジェクトとその子供オブジェクトにあるMeshRendererを全て取得する
    private MeshRenderer[] meshRenderers;
    //Start is called before the first frame update
    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();

        //自分と子供オブジェクトのMeshRendererを取得
        meshRenderers = GetComponentsInChildren<MeshRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        if (invincibleState == 1)
        {
            if(invincibleTime<=0.0f)
            {
                //StartCoroutine(Blink())はコルーチンを開始するメソッド
                //コルーチンはUnityの特別なメソッドで、時間をかけて処理を行うことができる
                //StartCoroutine(Blink())が無いとUpdate()の中で無敵状態の時に点滅する処理が実行されない
                StartCoroutine(Blink()); //無敵状態の時は点滅させる
            }
            invincibleTime += Time.deltaTime;
            boxCollider.enabled = false; //無敵状態の時は当たり判定を無効にする
            if (invincibleTime >= 2.0f)
            {
                invincibleState = 0;
                invincibleTime = 0.0f;
                //無敵時間が2秒経過したら無敵状態を解除する
            }
        }
        else if (invincibleState == 0)
        {
            boxCollider.enabled = true; //無敵状態でない時は当たり判定を有効にする
            foreach (var blink in meshRenderers) blink.enabled = true; // メッシュを表示する
            invincibleTime = 0.0f;
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

    //無敵状態の時に点滅させる処理
    private IEnumerator Blink()
    {
        for (int i = 0; i < blinkCount; i++)
        {
            // メッシュの表示・非表示を切り替える
            //blinkIntervalの時間ごとにメッシュを表示・非表示にする
            //blinkIntervalは0.1秒

            // var は型を自動で決めるもの。この場合の var は MeshRenderer 型の配列を指す
            // blinkは変数名。自由に決めることが出来ます。(blinkではなくAなどでもできる)
            // foreachは配列やリストの要素を一つずつ取り出すための構文
            // 今回の場合unity内のPlayerやplayerの子供オブジェクトにあるMeshRendererを一つずつ取り出している

            yield return new WaitForSeconds(blinkInterval); //指定した時間待機
            foreach(var blink in meshRenderers) blink.enabled = false; // メッシュを非表示にする

            yield return new WaitForSeconds(blinkInterval); //指定した時間待機
            foreach (var blink in meshRenderers) blink.enabled = true; // メッシュを表示する
            
        }

    }

}
