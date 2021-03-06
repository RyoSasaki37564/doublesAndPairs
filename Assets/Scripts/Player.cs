using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;  // DOTween を使うため

public class Player : MonoBehaviour
{
    int m_playerHpMax = 10000;
    public static int m_currentPHp; //現在のプレイヤーのHP
    public static int m_resultPHp; //前のターンのプレイヤーの最終HP

    public Text m_playerHPNum;

    /// <summary>スライダー</summary>
    public Slider m_pHPSlider;

    public float m_changeValueInterval = 1f; //値の変化速度

    // Start is called before the first frame update
    void Start()
    {
        m_playerHpMax = PlayerPrefs.GetInt("PlayerHp");
        m_pHPSlider = GameObject.Find("PlayerHpSlider").GetComponent<Slider>();
        m_currentPHp = m_playerHpMax;
        m_pHPSlider.maxValue = m_playerHpMax;
        m_pHPSlider.value = m_currentPHp;
        m_playerHPNum.text = m_currentPHp.ToString();

    }

    // Update is called once per frame
    void Update()
    {
        if(Skill.m_healFlg == true)
        {
            m_pHPSlider.value = m_currentPHp;
            m_playerHPNum.text = m_currentPHp.ToString();
            Skill.m_healFlg = false;
        }

        if(m_currentPHp > m_playerHpMax)
        {
            m_currentPHp = m_playerHpMax;
            m_pHPSlider.value = m_currentPHp;
            m_playerHPNum.text = m_currentPHp.ToString();
        }

        if (Enemy.m_currentEHp > 0)
        {

            if (GameManager.turn == GameManager.Turn.EnemyTurn) //敵の攻撃
            {
                Debug.Log("敵の攻撃");
                DOTween.To(() => m_currentPHp, x => m_currentPHp = x, m_currentPHp - Enemy.m_enemyAttack, m_changeValueInterval);
                DOTween.To(() => m_pHPSlider.value, x => m_pHPSlider.value = x, m_currentPHp - Enemy.m_enemyAttack, m_changeValueInterval)
                    .OnUpdate(() => m_playerHPNum.text = m_currentPHp.ToString())
                .OnComplete(() => m_playerHPNum.text = m_currentPHp.ToString());

                GameManager.turnFlag = true; //ドロップ操作用前提フラグ

                GameManager.turn = GameManager.Turn.CleanUpTurn; // リセットターンに変更
            }
        }
    }
    public int ThePMaxHP()
    {
        return PlayerPrefs.GetInt("PlayerHp");
    }
}
