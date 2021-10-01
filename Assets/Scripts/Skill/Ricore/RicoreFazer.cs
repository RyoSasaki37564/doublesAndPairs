using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoreFazer : Skill
{
    string[] m_charaName = new string[] { "プラズマボルト・リコア", "超光速の電撃・リコア" };
    public string[] m_fazeSetu = new string[] { "木属性攻撃時15%の追加ダメージ。", "「ライフスティール」\n" + "1ターンの間、相手の弱点属性で攻撃するたび、最大体力の1%を回復。",
        "「アクセラレーション」\n" +
        "1ターンの間、操作時間を10秒にし、0.3秒ごとにランダムなエナジーを1個生成する。(エナジー操作前のみ発動可能、時間効果は重複不可)" };

    public static bool m_RicoreCanUse = false; //最終フェイザーは発動条件あり

    // Start is called before the first frame update
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
            if (GameManager.turn == GameManager.Turn.InputTurn && m_RicoreCanUse == false)
            {
                RicoreLethalFazer.m_timeMinus = true;
                base.Fazer();
                m_RicoreCanUse = true;
            }
        }
        else
        {
            base.Fazer();
        }
    }
}
