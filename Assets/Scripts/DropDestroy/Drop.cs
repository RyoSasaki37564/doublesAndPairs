using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Drop : MonoBehaviour
{
    public abstract void DropDestroy();

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (Enemy.m_currentEHp >= 0)
            {

            }
        }
    }
}
