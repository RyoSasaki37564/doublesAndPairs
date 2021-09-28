using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssLethal : EnergyMatrix
{
    int m_DoubleDamageIce1; //水物理元値
    int m_DoubleDamageIce2; //水魔法元値

    public static bool m_isStack = false; //バフスキルの使用状態
    bool m_pioneerFlag = false; //このスキルがそのターンに使われたバフスキル内で最初かどうか

    // Start is called before the first frame update
    void Start()
    {
        //水属性の威力をその時の倍に上書きして、エナジー生成の再帰を起こし、そのターンで初めてこれと同じスキルを使うならそれを記録
        m_DoubleDamageIce1 = PlayerPrefs.GetInt("BlueS");
        m_DoubleDamageIce2 = PlayerPrefs.GetInt("BlueC");
        PlayerPrefs.SetInt("BlueS", m_DoubleDamageIce1 * 2);
        PlayerPrefs.SetInt("BlueC", m_DoubleDamageIce2 * 2);
        PlayerPrefs.Save();

        Generate();

        //バフスキルの初動を判定。攻撃力を戻すときに「最初の攻撃力」がどれなのかを記憶する処理。
        if (m_isStack == false)
        {
            m_isStack = true;
            m_pioneerFlag = true;
        }
    }

    void Update()
    {
        //ターンの終わりに効果終了
        if (GameManager.turn == GameManager.Turn.CleanUpTurn || GameManager.turn == GameManager.Turn.GameEnd ||
            GameManager.turn == GameManager.Turn.GameOut)
        {
            //最初の一体のみ、最初の威力に戻す
            if (m_pioneerFlag == true)
            {
                PlayerPrefs.SetInt("BlueS", m_DoubleDamageIce1);
                PlayerPrefs.SetInt("BlueC", m_DoubleDamageIce2);
                PlayerPrefs.Save();

                m_isStack = false;

                AbyssFazer.m_AbyssCanUse = false;//第一フェイザーの重複不可条件のリセット。演出の関係で第一の魚を消すのでこちらが引き継ぐ。
            }

            Destroy(this.gameObject);
        }
    }

    public override void Generate()
    {
        //エナジーマトリックスの再帰
        base.Generate();
        StartCoroutine(AbyssGene());
    }
    IEnumerator AbyssGene()
    {
        //エナジーマトリックスの再帰
        yield return new WaitForSeconds(1.0f);
        Generate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //スキル演出。画面上の魚全部食う
        if(collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
        }
    }
}
