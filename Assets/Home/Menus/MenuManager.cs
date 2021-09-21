using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuManager : MonoBehaviour
{
    public enum HomeMenu //ホーム画面における画面状態
    {
        Quest,
        Chara,
        Gacha,
    }
    public static HomeMenu menu;

    [SerializeField] int m_soul = 100; //疑似ゲーム内通貨。いわゆる「石」。

    //各メニューの実体化、隠蔽をスムーズにするために、それぞれのメニューに親オブジェクトを設定。それにSetActiveをかける。
    /// <summary>
    /// 要素は0からクエスト、キャラ、ガチャを入れること。
    /// </summary>
    [SerializeField] GameObject[] m_menuObj = new GameObject[3]; 

    // Start is called before the first frame update
    void Start()
    {
        menu = HomeMenu.Quest;
    }

    // Update is called once per frame
    void Update()
    {
        switch (menu)
        {
            case HomeMenu.Quest:
                m_menuObj[0].SetActive(true);
                m_menuObj[1].SetActive(false);
                m_menuObj[2].SetActive(false);
                break;

            case HomeMenu.Chara:
                m_menuObj[0].SetActive(false);
                m_menuObj[1].SetActive(true);
                m_menuObj[2].SetActive(false);
                break;

            case HomeMenu.Gacha:
                m_menuObj[0].SetActive(false);
                m_menuObj[1].SetActive(false);
                m_menuObj[2].SetActive(true);
                break;
        }
    }
}
