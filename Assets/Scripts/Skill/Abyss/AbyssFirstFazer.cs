using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssFirstFazer : MonoBehaviour
{
    float m_enemyPowerDefault = 0; //敵攻撃力の元の値
    bool m_isUse = false;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyPowerDefault = Enemy.m_enemyAttack;
        Enemy.m_enemyAttack = m_enemyPowerDefault / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.turn == GameManager.Turn.CleanUpTurn && m_isUse == false)
        {
            Enemy.m_enemyAttack = m_enemyPowerDefault;
            m_isUse = true;
        }
    }
}
