using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZukansParamator : MonoBehaviour
{
    [SerializeField] CharaID m_thisCharasStatus = default; //そのキャラのパラメーター

    //各パラメータのテキスト。 name, hp, fa...   fm, ia, im...   wa, wm, skill.
    [SerializeField] Text[] m_paramatorText = new Text[9];

   public void DataPanneling()
    {
        // ステータス表示
        for (var i = 1; i < 8; i++)
        {
            m_paramatorText[i].text = m_thisCharasStatus.m_status[i - 1].ToString();
        }

    }
}
