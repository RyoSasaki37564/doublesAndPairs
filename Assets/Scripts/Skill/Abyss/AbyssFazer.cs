﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssFazer : Skill
{
    string[] m_charaName = new string[] { "アビスの魚影" , "深海を喰らうもの"};
    string[] m_fazeSetu = new string[] { "発動したターン、受けるダメージを半減。", "リーサルフェイザーを使うまでの間、水属性の威力が1.2倍になる。",
        "「ディープブループレデター」 " +
        "1ターンの間、水属性の威力2倍、1秒ごとに水属性エナジーを1個生成する。" };

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