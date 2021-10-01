using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyuxFazer : Skill
{
    string[] m_charaName = new string[] { "夜の魔女・ニュクス", "宵闇の女神・ニュクス" };
    public string[] m_fazeSetu = new string[] { "「エナジーマトリックス・術」\n" + "プレイヤーターン中、5秒ごとに魔法エナジーを1個生成する。",
        "最大体力の30%を回復。", "「闇夜」" +
        "1ターンの間魔法攻撃力1.5倍、操作時間を7秒増やす。(エナジー操作前のみ発動可能、時間効果は重複不可)" };

    public static bool m_NyuxCanUse = false;

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
        if (m_faze == Faze.Lethal)
        {
            if(GameManager.turn == GameManager.Turn.InputTurn && m_NyuxCanUse == false)
            {
                NyuxLethalFazer.m_timePlus = true;
                base.Fazer();
                m_NyuxCanUse = true;
            }
        }
        else
        {
            base.Fazer();
        }
    }
}