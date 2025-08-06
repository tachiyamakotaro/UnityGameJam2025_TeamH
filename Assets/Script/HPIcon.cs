using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HPIcon : MonoBehaviour
{
    [SerializeField, Header("HPÉAÉCÉRÉì")]
    private GameObject hpIconPrefab;

    private Player_HP playerHP;
    private int _beforeHP;
    private List<GameObject> hpIcons;

    // Start is called before the first frame update
    void Start()
    {
        playerHP = FindObjectOfType<Player_HP>();
        _beforeHP = playerHP.GetHP();
        hpIcons = new List<GameObject>();
        CreateHPIcon();
    }

    private void CreateHPIcon()
    {
        for (int i = 0; i < playerHP.GetHP(); i++)
        {
            GameObject hpIcon = Instantiate(hpIconPrefab);
            hpIcon.transform.SetParent(transform);
            hpIcons.Add(hpIcon);
        }
    }

    // Update is called once per frame
    void Update()
    {
        ShowHPIcon();
    }

    private void ShowHPIcon()
    {
        if (_beforeHP == playerHP.GetHP()) return;

        for(int i=0;i<hpIcons.Count;i++)
        {
            hpIcons[i].SetActive(i<playerHP.GetHP());
        }
        _beforeHP = playerHP.GetHP();
    }
}
