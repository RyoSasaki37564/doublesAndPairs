using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zukan_4 : ZukansParamator
{
    [SerializeField] Text m_skillSetumei = default; //パネルの説明入れ

    [SerializeField] NyuxFazer m_thisFazer = default; //こやつのスキル

    string m_faze1, m_faze2, m_lethal;

    [SerializeField] GameObject m_charaStats = default; //キャラステ表示パネル

    public override void DataPanneling()
    {
        m_faze1 = m_thisFazer.m_fazeSetu[0];
        m_faze2 = m_thisFazer.m_fazeSetu[1];
        m_lethal = m_thisFazer.m_fazeSetu[2];

        m_skillSetumei.text = "ファーストフェイザー : " + m_faze1 + "\n" + "\n" +
            "セカンドフェイザー : " + m_faze2 + "\n" + "\n" +
            "リーサルフェイザー : " + m_lethal + "\n" + "\n" + "[ドロップ報酬のみ] BossQuest ～戦場からの挑戦状～";

        base.DataPanneling();

        m_charaStats.SetActive(true);
    }
}
