using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestFazer : Skill
{
    string[] m_charaName = new string[]{ "ワルキューレの奇行", "ヴァルハラの騎士・ワルキューレ"};
    public string[] m_fazeSetu = new string[] { "敵に10000の固定ダメージ。", "敵から体力を2500吸収。", "「ワルキューレ砲」\n" +
        "敵の現在HPを30%減らす。" };

    public void Update()
    {

        switch (m_faze)
        {
            case Faze.First:
                StatusPanneler(m_charaName[0], m_fazeSetu[0]);
                break;
            case Faze.Second:
                StatusPanneler(m_charaName[0], m_fazeSetu[1]);
                break;
            case Faze.Lethal:
                StatusPanneler(m_charaName[1], m_fazeSetu[2]);
                break;

        }

    }

    public override void Fazer()
    {
        base.Fazer();
    }
}
