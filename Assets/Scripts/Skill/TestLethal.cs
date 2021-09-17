using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLethal : MonoBehaviour
{
    Player m_p = new Player();

    public void Lethal()
    {
        Enemy.m_currentEHp -= m_p.ThePMAXHP();
        Destroy(gameObject);
    }
}
