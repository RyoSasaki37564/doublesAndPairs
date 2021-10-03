using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSecondFazer : NyuxFirstFazer //フェイザーからエナジーマトリックス系を使う
{
    int m_turnCount = 0;

    bool m_flg = false;

    public override void Generate()
    {
        base.Generate();
        
    }

    private void Update()
    {
        if (GameManager.turn == GameManager.Turn.CleanUpTurn && m_flg == false)
        {
            m_turnCount++;
            m_flg = true;
            if (m_turnCount == 3)
            {
                Destroy(this.gameObject);
            }
        }

        if(GameManager.turn != GameManager.Turn.CleanUpTurn && m_flg == true)
        {
            m_flg = false;
        }

    }
}
