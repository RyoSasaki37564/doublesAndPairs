using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssFirstFazer : MonoBehaviour
{
    int m_enemyPowerDefault = 0; //敵攻撃力の元の値
    Enemy m_e = new Enemy();

    // Start is called before the first frame update
    void Start()
    {
        m_enemyPowerDefault = m_e.EnemyCurrentAttack();
        Enemy.m_enemyAttack = m_enemyPowerDefault / 2;
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.turn == GameManager.Turn.CleanUpTurn && AbyssFazer.m_AbyssCanUse == true)
        {
            Enemy.m_enemyAttack = m_enemyPowerDefault;
            AbyssFazer.m_AbyssCanUse = false;
        }
    }
}
