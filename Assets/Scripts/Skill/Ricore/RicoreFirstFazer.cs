using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoreFirstFazer : MonoBehaviour
{
    int m_takenDamageWood1;
    int m_takenDamageWood2;

    // Start is called before the first frame update
    void Start()
    {
        m_takenDamageWood1 = (PlayerPrefs.GetInt("GreenS") * 15)/100;
        m_takenDamageWood2 = (PlayerPrefs.GetInt("GreenC") * 15)/100;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (GreenDropDestroy.woodAttackFlag == true)
            {
                Enemy.m_currentEHp -= m_takenDamageWood1;
            }
            if (GreenDropDestroy.woodMagicFlag == true)
            {
                Enemy.m_currentEHp -= m_takenDamageWood2;
            }
        }
    }
}
