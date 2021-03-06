using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyuxFirstFazer : EnergyMatrix
{
    //フェイザースキルからパーマネント展開をする処理。位置はプライマリーデフォルトの真逆になるように設計した。
    Vector2 m_parmanentPos;

    float m_x = -2.48f;
    float m_y = 4.49f;

    public static int m_num = 0;

    private void Start()
    {
        m_parmanentPos = new Vector2(m_x, m_y);
        if (m_num < 3)
        {
            this.gameObject.transform.position = new Vector2(m_parmanentPos.x,
                m_parmanentPos.y - 0.8f*m_num);
        }
        else
        {
            this.gameObject.transform.position = new Vector2(m_parmanentPos.x + 0.7f,
                m_parmanentPos.y - 0.8f * (m_num - 3));
        }
        m_num++;
    }

    private void Update()
    {
        if (GameManager.turn == GameManager.Turn.GameOut || GameManager.turn == GameManager.Turn.GameEnd
            || GiveUp.m_akirame == true || Player.m_currentPHp <= 0)
        {
            m_num = 0;
        }
    }
    public override void Generate()
    {
        base.Generate();
    }
}
