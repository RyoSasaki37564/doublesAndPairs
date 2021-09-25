using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Regene : MonoBehaviour
{
    Player m_p = new Player();

    void Regeneration()
    {
        if(Player.m_currentPHp < m_p.ThePMaxHP() && GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            Player.m_currentPHp += m_p.ThePMaxHP() / 100;
            Skill.m_healFlg = true;
        }
    }
}
