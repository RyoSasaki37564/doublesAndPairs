using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyuxLethalFazer : MonoBehaviour
{
    int m_MagicDamageFire; //火魔法元値
    int m_MagicDamageIce; //水魔法元値
    int m_MagicDamageWood; //木魔法元値

    bool m_pioneerFlag = false; //このスキルがそのターンに使われたバフスキル内で最初かどうか

    public static bool m_timePlus = false;

    GameManager m_g = new GameManager();

    // Start is called before the first frame update
    void Start()
    {
        m_MagicDamageFire = PlayerPrefs.GetInt("RedC");
        m_MagicDamageIce = PlayerPrefs.GetInt("BlueC");
        m_MagicDamageWood = PlayerPrefs.GetInt("Green");
        PlayerPrefs.SetInt("RedC", (m_MagicDamageFire * 3) / 2);
        PlayerPrefs.SetInt("BlueC", (m_MagicDamageIce * 3) / 2);
        PlayerPrefs.SetInt("Green", (m_MagicDamageWood * 3) / 2);
        PlayerPrefs.Save();
        if (AbyssLethal.m_isStack == false)
        {
            AbyssLethal.m_isStack = true;
            m_pioneerFlag = true;
        }
        if(m_timePlus == false)
        {
            m_timePlus = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            //最初の一体のみ、最初の威力に戻す
            if (m_pioneerFlag == true)
            {
                PlayerPrefs.SetInt("RedC", m_MagicDamageFire);
                PlayerPrefs.SetInt("BlueC", m_MagicDamageIce);
                PlayerPrefs.SetInt("Green", m_MagicDamageWood);
                PlayerPrefs.Save();

                AbyssLethal.m_isStack = false;
            }
            m_timePlus = false;
            NyuxFazer.m_NyuxCanUse = false;
            Destroy(this.gameObject);
        }
    }
}
