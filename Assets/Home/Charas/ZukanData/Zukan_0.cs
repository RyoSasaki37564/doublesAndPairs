using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zukan_0 : ZukansParamator
{
    [SerializeField] Text m_skillSetumei = default; //パネルの説明入れ

    [SerializeField] TestFazer m_thisFazer = default; //こやつのスキル

    string m_faze1, m_faze2, m_lethal;

    [SerializeField] GameObject m_charaStats = default; //キャラステ表示パネル

    public override void DataPanneling()
    {
        m_faze1 = m_thisFazer.m_fazeSetu[0];
        m_faze2 = m_thisFazer.m_fazeSetu[1];
        m_lethal = m_thisFazer.m_fazeSetu[2];

        m_skillSetumei.text = m_faze1 + "\n" + m_faze2  + "\n" + m_lethal;

        base.DataPanneling();

        m_charaStats.SetActive(true);
    }
}
