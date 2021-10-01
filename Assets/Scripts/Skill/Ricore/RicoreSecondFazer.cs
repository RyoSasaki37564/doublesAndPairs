using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoreSecondFazer : MonoBehaviour
{
    Player m_p = new Player();

    // Update is called once per frame
    void FixedUpdate()
    {
        //敵の弱点を突くと回復
        if (Player.m_currentPHp < m_p.ThePMaxHP() &&
            GameManager.turn == GameManager.Turn.PlayerTurn || GameManager.turn == GameManager.Turn.InputTurn)
        {
            if (Enemy.m_enemyZokusei == 0)
            {
                if (BlueDropDestroy.iceAttackFlag == true || BlueDropDestroy.iceMagicFlag == true)
                {
                    Player.m_currentPHp += m_p.ThePMaxHP() * 25 / 100;
                    Debug.LogError(Player.m_currentPHp);
                    Skill.m_healFlg = true;
                }
            }
            else if (Enemy.m_enemyZokusei == 1)
            {
                if (GreenDropDestroy.woodAttackFlag == true || GreenDropDestroy.woodMagicFlag == true)
                {
                    Player.m_currentPHp += m_p.ThePMaxHP() * 25 / 100;
                    Debug.LogError(Player.m_currentPHp);
                    Skill.m_healFlg = true;
                }
            }
            else if (Enemy.m_enemyZokusei == 2)
            {
                if (RedDropDestroy.fireAttackFlag == true || RedDropDestroy.fireMagicFlag == true)
                {
                    Player.m_currentPHp += m_p.ThePMaxHP() * 25 / 100;
                    Debug.LogError(Player.m_currentPHp);
                    Skill.m_healFlg = true;
                }
            }

            //ターンの終わりに効果破棄
            if (GameManager.turn == GameManager.Turn.CleanUpTurn || GiveUp.m_akirame == true)
            {
                Destroy(this.gameObject);
            }
        }
    }
}
