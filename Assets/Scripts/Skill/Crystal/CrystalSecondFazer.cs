using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSecondFazer : NyuxFirstFazer
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
            Debug.LogError(m_turnCount);
            m_turnCount++;
            m_flg = true;
            if (m_turnCount == 2)
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
