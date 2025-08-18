using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy_KillCount : MonoBehaviour
{
    public static Enemy_KillCount instance; // �V���O���g���łǂ�����ł��A�N�Z�X�\��

    private int killCount = 0; // �|�����G�̐�
    [SerializeField] private int targetKillCount = 20; // �N���A�����ƂȂ錂�j��

    [SerializeField] private TextMeshProUGUI remainingText; // �c�萔�\���p

    // Start is called before the first frame update
    void Start()
    {
        UpdateUI(); // ������Ԃ�UI���X�V
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject); // �d��������j��
    }

    // �G���|���ꂽ�Ƃ��ɌĂ΂�郁�\�b�h
    public void AddKillCount()
    {
        killCount++;
        //Debug.Log("�|�����G�̐�: " + killCount);
        UpdateUI(); // UI���X�V

        if (killCount >= targetKillCount)
        {
            SceneManager.LoadScene("GameClear"); // ���V�[���J��
        }
    }

    private void UpdateUI()
    {
        int remaining = targetKillCount - killCount;
        remainingText.text = "�c��" + remaining.ToString()+"��";
    }
}
