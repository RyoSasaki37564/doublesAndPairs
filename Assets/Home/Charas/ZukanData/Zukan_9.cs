﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Zukan_9 : ZukansParamator
{
    [SerializeField] Text m_skillSetumei = default; //パネルの説明入れ

    [SerializeField] TestMandara m_thisPD = default; //こやつのスキル

    string m_setu;

    [SerializeField] GameObject m_charaStats = default; //キャラステ表示パネル

    public override void DataPanneling()
    {
        m_setu = m_thisPD.m_setumei;

        m_skillSetumei.text = "プライマリーデフォルト : " + m_setu;

        base.DataPanneling();

        m_charaStats.SetActive(true);
    }
}