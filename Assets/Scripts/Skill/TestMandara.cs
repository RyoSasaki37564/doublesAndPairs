using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestMandara : PrimaryDefault
{
    string m_name = "ゲヘナ";
    string m_setumei = "「エナジーマトリックス・火」\n" + "プレイヤーターン中、3秒ごとに火属性エナジーを1個生成する。";

    // Update is called once per frame
    void Awake()
    {
        StatusPanneler(m_name, m_setumei);
    }

    public override void Parmanent()
    {
        base.Parmanent();
    }

}
