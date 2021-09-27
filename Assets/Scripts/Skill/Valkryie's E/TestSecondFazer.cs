using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestSecondFazer : MonoBehaviour
{
    [SerializeField] int m_SecondFazerDrain = 2500;

    public void Second()
    {
        Enemy.m_currentEHp -= m_SecondFazerDrain;
        Player.m_currentPHp += m_SecondFazerDrain;
        Skill.m_healFlg = true;
        Destroy(gameObject);
    }
}
