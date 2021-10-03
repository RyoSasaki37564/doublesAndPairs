using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ValtorPrimaryDefault : PrimaryDefault
{
    string m_name = "極撃の剛剣・ヴァルター";
    public string m_setumei = "「一刀両断」\n" +
        "【チャージ攻撃】発生させた物理攻撃力を「チャージ」し、3ターンごとの操作時間開始時に1.4倍にして攻撃する。";

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
