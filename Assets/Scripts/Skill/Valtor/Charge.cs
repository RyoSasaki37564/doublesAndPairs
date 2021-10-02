using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    int m_chargePower = 0; //チャージ威力

    int m_turnCount = 0; //解放カウント

    [SerializeField] int m_liberationTurn = 3; //チャージ攻撃を実行するターン間隔。

    //物理攻撃威力をカウント
    int m_takenDamageFire = 0;
    int m_takenDamageIce = 0;
    int m_takenDamageWood = 0;

    // Start is called before the first frame update
    void Start()
    {
        m_turnCount = 0;
        m_chargePower = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (BlueDropDestroy.iceAttackFlag == true)
            {
                m_chargePower += m_takenDamageWood1;
            }
        }

        if (GameManager.turn == GameManager.Turn.GameOut || GameManager.turn == GameManager.Turn.GameEnd
            || GiveUp.m_akirame == true)
        {
            Destroy(this.gameObject);
        }
    }
}
