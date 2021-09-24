using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssSecondFazer : MonoBehaviour
{
    float m_takenDamageIce1;
    float m_takenDamageIce2;

    // Start is called before the first frame update
    void Start()
    {
        m_takenDamageIce1 = PlayerPrefs.GetInt("BlueS") * 0.2f;
        m_takenDamageIce2 = PlayerPrefs.GetInt("BlueC") * 0.2f;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (BlueDropDestroy.iceAttackFlag == true)
            {
                Enemy.m_currentEHp -= (int)m_takenDamageIce1;
            }
            if (BlueDropDestroy.iceMagicFlag == true)
            {
                Enemy.m_currentEHp -= (int)m_takenDamageIce2;
            }
        }
    }
}
