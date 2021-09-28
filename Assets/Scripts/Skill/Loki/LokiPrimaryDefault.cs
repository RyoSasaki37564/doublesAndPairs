using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiPrimaryDefault : PrimaryDefault
{
    string m_name = "ラグナロクの元凶・ロキ";
    public string m_setumei = "「ゴッドオブトリックスター」\n" +
        "1ターンの間、敵と同じ属性の威力が2倍、敵の属性を「敵の現在の有利属性（例：元が火なら木へ）」に変える。";

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
