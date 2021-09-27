using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestRegeneration : PrimaryDefault
{
    string m_name = "エヴァーグリーン";
    string m_setumay = "「リジェネ」\n" + "操作時間中、3秒ごとに最大体力の1%を回復。";

    private void Awake()
    {
        StatusPanneler(m_name, m_setumay);
    }

    public override void Parmanent()
    {
        base.Parmanent();
    }
}
