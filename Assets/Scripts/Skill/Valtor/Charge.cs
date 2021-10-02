using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Charge : MonoBehaviour
{
    int m_chargePower = 0; //チャージ威力

    int m_turnCount = -1; //解放カウント。-1からなのはバトルの始めにインクリメントして0にするため
    bool m_countOnOff = false; //カウントの制御。

    [SerializeField] int m_liberationTurn = 3; //チャージ攻撃を実行するターン間隔。

    //物理攻撃威力をカウント
    int m_takenDamageFire;
    int m_takenDamageIce;
    int m_takenDamageWood;

    [Tooltip("この値は10で割られる。")] 
    [SerializeField] int m_bairitu = 14;

    bool m_canAttack = false; //1ターン目にいはおりてるが、にターン目以降は上がるフラグ。

    // Start is called before the first frame update
    void Start()
    {
        //初期化。
        m_takenDamageFire = PlayerPrefs.GetInt("RedS");
        m_takenDamageIce = PlayerPrefs.GetInt("BlueS");
        m_takenDamageWood = PlayerPrefs.GetInt("GreenS");

        m_turnCount = -1;
        m_chargePower = 0;

        m_canAttack = false;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            //物理攻撃値を計測、チャージ
            m_takenDamageFire = PlayerPrefs.GetInt("RedS");
            m_takenDamageIce = PlayerPrefs.GetInt("BlueS");
            m_takenDamageWood = PlayerPrefs.GetInt("GreenS");

            if (RedDropDestroy.fireAttackFlag == true)
            {
                m_chargePower += m_takenDamageFire;
                Debug.LogError(m_chargePower);
            }
            else if (BlueDropDestroy.iceAttackFlag == true)
            {
                m_chargePower += m_takenDamageIce;
                Debug.LogError(m_chargePower);
            }
            else if(GreenDropDestroy.woodAttackFlag == true)
            {
                m_chargePower += m_takenDamageWood;
                Debug.LogError(m_chargePower);
            }

            
        }

        if(GameManager.turn == GameManager.Turn.PlayerTurn && m_countOnOff == false)
        {
            //ターン終了時、カウントを進める。
            m_turnCount++;
            Debug.LogError("ターン" + m_turnCount);
            
            //チャージ開放
            if (m_turnCount % m_liberationTurn == 0 && m_canAttack == true)
            {
                Enemy.m_currentEHp -= m_chargePower * m_bairitu / 10;
                Debug.LogError("アタック！" + m_chargePower);
                m_chargePower = 0;
                m_canAttack = false;
            }

            m_countOnOff = true;
        }

        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_countOnOff = false;
            m_canAttack = true;
        }

        if (GameManager.turn == GameManager.Turn.GameOut || GameManager.turn == GameManager.Turn.GameEnd
            || GiveUp.m_akirame == true)
        {
            m_countOnOff = false;
            Destroy(this.gameObject);
        }
    }
}
