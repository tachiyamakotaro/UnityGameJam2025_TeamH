using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_KillCount : MonoBehaviour
{
    public static Enemy_KillCount instance; // シングルトンでどこからでもアクセス可能に

    private int killCount = 0; // 倒した敵の数
    [SerializeField] private int targetKillCount = 20; // クリア条件となる撃破数

    [SerializeField] private TextMeshProUGUI remainingText; // 残り数表示用

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(); // 初期状態のUIを更新
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); // 重複したら破棄
    }

    // 敵が倒されたときに呼ばれるメソッド
    public void AddKillCount()
    {
        killCount++;
        //Debug.Log("倒した敵の数: " + killCount);
        UpdateUI(); // UIを更新

        if (killCount >= targetKillCount)
        {
            SceneManager.LoadScene("GameClear"); // 即シーン遷移
        }
    }

    private void UpdateUI()
    {
        int remaining = targetKillCount - killCount;
        remainingText.text = "残り" + remaining.ToString()+"体";
    }
}
