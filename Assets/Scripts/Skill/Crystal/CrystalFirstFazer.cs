using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalFirstFazer : MonoBehaviour
{
    Player m_p = new Player();

    void Start()
    {
        if (Player.m_currentPHp < m_p.ThePMaxHP() &&
            GameManager.turn == GameManager.Turn.PlayerTurn || GameManager.turn == GameManager.Turn.InputTurn)
        {
            Player.m_currentPHp += (m_p.ThePMaxHP() * 20) / 100;
            Skill.m_healFlg = true;
        }

    }
}