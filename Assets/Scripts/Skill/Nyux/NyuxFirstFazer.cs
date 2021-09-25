using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NyuxFirstFazer : EnergyMatrix
{
    //フェイザースキルからパーマネント展開をする処理。位置はプライマリーデフォルトとは逆になるように設計した。
    GameObject m_parmanentPos;

    static int m_num = 0;

    private void Start()
    {
        m_parmanentPos = GameObject.Find("ParmanentPos");
        this.gameObject.transform.position = new Vector2(m_parmanentPos.transform.position.x*-1, m_parmanentPos.transform.position.y);
        m_num++;
        if (m_num < 3 && m_num != 0)
        {
            this.gameObject.transform.position = new Vector2(m_parmanentPos.transform.position.x*-1,
                m_parmanentPos.transform.position.y - 0.8f);
        }
        else
        {
            this.gameObject.transform.position = new Vector2(m_parmanentPos.transform.position.x*-1 - 0.7f,
                m_parmanentPos.transform.position.y - 0.8f * (m_num - 3));
        }
    }

    private void Update()
    {
        if(GameManager.turn == GameManager.Turn.GameOut || GameManager.turn == GameManager.Turn.GameEnd)
        {
            m_num = 0;
        }
    }
    public override void Generate()
    {
        base.Generate();
    }
}
