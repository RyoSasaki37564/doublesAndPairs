using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LokiTheTrickStar : MonoBehaviour
{
    int m_DoubleDamageAttack; //物理元値
    int m_DoubleDamageMagic; //魔法元値

    bool m_pioneerFlag = false; //このスキルがそのターンに使われたバフスキル内で最初かどうか

    enum TrickZokusei
    {
        FireBuff,
        IceBuff,
        WoodBuff,
    }

    TrickZokusei m_trick; //どのバフが入ったかをenumで取得。効果終了処理に使用

    // Start is called before the first frame update
    void Start()
    {
        // 敵の属性に応じたバフを振り、敵の属性を弱点に変化
        if(Enemy.m_enemyZokusei == 0)
        {
            m_DoubleDamageAttack = PlayerPrefs.GetInt("RedS");
            m_DoubleDamageMagic = PlayerPrefs.GetInt("RedC");
            PlayerPrefs.SetInt("RedS", m_DoubleDamageAttack * 2);
            PlayerPrefs.SetInt("RedC", m_DoubleDamageMagic * 2);
            PlayerPrefs.Save();
            Enemy.m_enemyZokusei = 2;
            m_trick = TrickZokusei.FireBuff;
        }
        else if(Enemy.m_enemyZokusei == 1)
        {
            m_DoubleDamageAttack = PlayerPrefs.GetInt("BlueS");
            m_DoubleDamageMagic = PlayerPrefs.GetInt("BlueC");
            PlayerPrefs.SetInt("BlueS", m_DoubleDamageAttack * 2);
            PlayerPrefs.SetInt("BlueC", m_DoubleDamageMagic * 2);
            PlayerPrefs.Save();
            Enemy.m_enemyZokusei = 0;
            m_trick = TrickZokusei.IceBuff;
        }
        else
        {
            m_DoubleDamageAttack = PlayerPrefs.GetInt("GreenS");
            m_DoubleDamageMagic = PlayerPrefs.GetInt("GreenC");
            PlayerPrefs.SetInt("GreenS", m_DoubleDamageAttack * 2);
            PlayerPrefs.SetInt("GreenC", m_DoubleDamageMagic * 2);
            PlayerPrefs.Save();
            Enemy.m_enemyZokusei = 1;
            m_trick = TrickZokusei.WoodBuff;
        }

        //バフスキルの初動を判定。攻撃力を戻すときに「最初の攻撃力」がどれなのかを記憶する処理。
        if (AbyssLethal.m_isStack == false)
        {
            AbyssLethal.m_isStack = true;
            m_pioneerFlag = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ターンの終わりに効果破棄

        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            //最初の一体のみ、最初の威力に戻す
            if (m_pioneerFlag == true)
            {
                switch (m_trick)
                {
                    case TrickZokusei.FireBuff:
                        PlayerPrefs.SetInt("RedS", m_DoubleDamageAttack);
                        PlayerPrefs.SetInt("RedC", m_DoubleDamageMagic);
                        PlayerPrefs.Save();
                        break;

                    case TrickZokusei.IceBuff:
                        PlayerPrefs.SetInt("BlueS", m_DoubleDamageAttack);
                        PlayerPrefs.SetInt("BlueC", m_DoubleDamageMagic);
                        PlayerPrefs.Save();
                        break;

                    case TrickZokusei.WoodBuff:
                        PlayerPrefs.SetInt("GreenS", m_DoubleDamageAttack);
                        PlayerPrefs.SetInt("GreenC", m_DoubleDamageMagic);
                        PlayerPrefs.Save();
                        break;
                }

                AbyssLethal.m_isStack = false;

                Destroy(this.gameObject);
            }
        }
    }
}
