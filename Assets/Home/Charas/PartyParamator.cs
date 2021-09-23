using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PartyParamator : MonoBehaviour
{
    public static int m_hp = 0;//パーティ体力

    public static int m_fireButuri = 0;//パーティ火属性物理

    public static int m_fireMahou = 0;//パーティ火属性魔法

    public static int m_iceButuri = 0;//パーティ水属性物理

    public static int m_iceMahou = 0; //パーティ水属性魔法

    public static int m_woodButuri = 0;//パーティ木属性物理

    public static int m_woodMahou = 0;//パーティ木属性魔法

    [SerializeField] Text[] m_PartyStatusPanel = new Text[7];

    bool m_panelOnOff = false;

    [SerializeField]GameObject m_PartyStatusPanelObj = default;

    // Start is called before the first frame update
    void Start()
    {
        //パーティステータス初期化
        PlayerPrefs.SetInt("PlayerHp", 0);
        m_hp = PlayerPrefs.GetInt("PlayerHp");

        PlayerPrefs.SetInt("RedS", 0);
        m_fireButuri = PlayerPrefs.GetInt("RedS", 0);
        PlayerPrefs.SetInt("RedC", 0);
        m_fireMahou = PlayerPrefs.GetInt("RedC", 0);

        PlayerPrefs.SetInt("BlueS", 0);
        m_iceButuri = PlayerPrefs.GetInt("BlueS", 0);
        PlayerPrefs.SetInt("BlueC", 0);
        m_iceMahou = PlayerPrefs.GetInt("BlueC", 0);

        PlayerPrefs.SetInt("GreenS", 0);
        m_woodButuri = PlayerPrefs.GetInt("GreenS", 0);
        PlayerPrefs.SetInt("GreenC", 0);
        m_woodMahou = PlayerPrefs.GetInt("GreenC", 0);

        PlayerPrefs.Save();
        m_PartyStatusPanelObj.SetActive(false);
    }

    public void PartyStatusView()
    {
        //パーティステータスを表示
        if(m_panelOnOff == false)
        {
            m_PartyStatusPanel[0].text = "体力: " + PlayerPrefs.GetInt("PlayerHp").ToString();
            m_PartyStatusPanel[1].text = "火属性攻撃力: " + PlayerPrefs.GetInt("RedS").ToString();
            m_PartyStatusPanel[2].text = "火属性魔法力: " + PlayerPrefs.GetInt("RedC").ToString();
            m_PartyStatusPanel[3].text = "水属性攻撃力: " + PlayerPrefs.GetInt("BlueS").ToString();
            m_PartyStatusPanel[4].text = "水属性魔法力: " + PlayerPrefs.GetInt("BlueC").ToString();
            m_PartyStatusPanel[5].text = "木属性攻撃力: " + PlayerPrefs.GetInt("GreenS").ToString();
            m_PartyStatusPanel[6].text = "木属性魔法力: " + PlayerPrefs.GetInt("GreenC").ToString();

            m_PartyStatusPanelObj.SetActive(true);

            m_panelOnOff = true;

        }
        else
        {
            m_panelOnOff = false;
            m_PartyStatusPanelObj.SetActive(false);
        }
    }
}
