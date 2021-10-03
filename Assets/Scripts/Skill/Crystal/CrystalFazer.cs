using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalFazer : Skill
{
    string[] m_charaName = new string[] { "水晶の少女・クリスタル", "解けざる氷・クリスタル" };
    public string[] m_fazeSetu = new string[] { "最大体力の20%を回復。",
        "「エナジーブースト・水」\n" + "3ターンの間、2秒ごとに水属性エナジーを1個生成する。",
        "「トータル・ディフェンダー」\n" + "1ターンの間、敵の攻撃を無効化する。" };

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
