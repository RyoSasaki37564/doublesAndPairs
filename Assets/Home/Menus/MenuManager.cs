using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    public enum HomeMenu //ホーム画面における画面状態
    {
        Quest,
        Chara,
        Gacha,
    }
    public static HomeMenu menu;

    public static int m_soul = 100; //疑似ゲーム内通貨。いわゆる「石」。

    [SerializeField] Text[] m_MenuHeadText = new Text[2]; //今いるメニューと石の数を表記

    /// <summary>
    /// 各メニューの実体化、隠蔽をスムーズにするために、それぞれのメニューに親オブジェクトを設定。それにSetActiveをかける。
    /// 要素は0からクエスト、キャラ、ガチャ。
    /// </summary>
    [SerializeField] GameObject[] m_menuObj = new GameObject[3]; 

    // Start is called before the first frame update
    void Start()
    {
        m_menuObj[0].SetActive(false);
        m_menuObj[1].SetActive(false);
        m_menuObj[2].SetActive(false);
        menu = HomeMenu.Quest;
        m_MenuHeadText[0].text = menu.ToString();
        m_MenuHeadText[1].text = "所持ソウル: "+ m_soul.ToString();
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
                m_MenuHeadText[0].text = menu.ToString();
                break;

            case HomeMenu.Chara:
                m_menuObj[0].SetActive(false);
                m_menuObj[1].SetActive(true);
                m_menuObj[2].SetActive(false);
                m_MenuHeadText[0].text = menu.ToString();
                break;

            case HomeMenu.Gacha:
                m_menuObj[0].SetActive(false);
                m_menuObj[1].SetActive(false);
                m_menuObj[2].SetActive(true);
                m_MenuHeadText[0].text = menu.ToString();
                break;
        }
    }
}
