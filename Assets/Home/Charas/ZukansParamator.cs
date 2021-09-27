using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukansParamator : MonoBehaviour
{
    [SerializeField] CharaID m_thisCharasStatus = default; //そのキャラのパラメーター

    //各パラメータのテキスト。 name, hp, fa. fm, ia, im. wa, wm, skill.
    [SerializeField] Text[] m_paramatorText = new Text[9];

    [SerializeField] GameObject m_charaStats = default; //キャラステ表示パネル

    string m_statsType; //すてーたすしゅべつ

    [SerializeField] string m_onamae = default;



   public void DataPanneling()
    {
        m_paramatorText[0].text = m_onamae;

        // ステータス表示
        for (var i = 1; i < 8; i++)
        {
            if (i == 1)
            {
                m_statsType = "体力";
            }
            else if (i == 2)
            {
                m_statsType = "火属性攻撃力";
            }
            else if (i == 3)
            {
                m_statsType = "火属性魔法力";
            }
            else if (i == 4)
            {
                m_statsType = "水属性攻撃力";
            }
            else if (i == 5)
            {
                m_statsType = "水属性魔法力";
            }
            else if (i == 6)
            {
                m_statsType = "木属性攻撃力";
            }
            else
            {
                m_statsType = "木属性魔法力";
            }

            m_paramatorText[i].text =  m_statsType + " : " +  m_thisCharasStatus.m_status[i - 1].ToString();
        }
        m_charaStats.SetActive(true);
    }
}
