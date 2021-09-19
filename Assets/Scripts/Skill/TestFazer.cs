using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class TestFazer : Skill
{
    string[] m_charaName = new string[]{ "ワルキューレの奇行" };
    string[] m_fazeSetu = new string[] { "敵にやや強めの攻撃。", "敵から体力を吸収。", "必殺ワルキューレミサイル。　" +
        "パーティー最大HPの50%のダメージ。" };

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
                StatusPanneler(m_charaName[0], m_fazeSetu[2]);
                break;

        }

    }

    public override void Fazer()
    {
        base.Fazer();
    }
}
