using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SEMEnemyAttack : MonoBehaviour
{
    AudioSource m_enemyAttackSE;

    // Start is called before the first frame update
    void Start()
    {
        m_enemyAttackSE = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {

        if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            m_enemyAttackSE.PlayOneShot(m_enemyAttackSE.clip);
        }

    }
}
