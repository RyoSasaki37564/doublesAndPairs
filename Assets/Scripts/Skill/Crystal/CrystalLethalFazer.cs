using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalLethalFazer : MonoBehaviour
{
    int m_enemyPowerDefault = 0; //敵攻撃力の元の値
    Enemy m_e = new Enemy();

    public static bool m_isDefStack = false; //防御スキルの使用状態
    bool m_pioneerFlag = false; //このスキルがそのターンに使われた防御スキル内で最初かどうか

    // Start is called before the first frame update
    void Start()
    {
        m_enemyPowerDefault = m_e.EnemyCurrentAttack();
        Enemy.m_enemyAttack = 0;

        //防御スキルの初動を判定。敵攻撃力を戻すときに「最初の攻撃力」がどれなのかを記憶する処理。
        if (m_isDefStack == false)
        {
            m_isDefStack = true;
            m_pioneerFlag = true;
        }

    }

    // Update is called once per frame
    void Update()
    {
        //効果中に敵を倒したら破棄
        if(Enemy.m_currentEHp <= 0)
        {
            m_isDefStack = false;
            Destroy(this.gameObject);
        }

        //ターンの終わり、退却時に効果終了
        if (GameManager.turn == GameManager.Turn.CleanUpTurn || GameManager.turn == GameManager.Turn.GameEnd ||
            GameManager.turn == GameManager.Turn.GameOut || GiveUp.m_akirame == true)
        {
            //最初の一体のみ、最初の威力に戻す
            if (m_pioneerFlag == true)
            {

                Enemy.m_enemyAttack = m_enemyPowerDefault;
                m_isDefStack = false;

            }

            Destroy(this.gameObject);
        }
    }
}