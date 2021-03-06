using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;

public class Enemy : MonoBehaviour
{
    //シリアライズでCSVファイルをドラッグアンドドロップ。そしてこれを入れたオブジェクトをボタンの窓に持ってって簡単読み込み。
    [SerializeField] List<TextAsset> m_csv = new List<TextAsset>();

    public static int m_QuestMasterID; //クエスト番号

    [SerializeField] List<Sprite> m_enemySprites = new List<Sprite>(); //敵の画像リスト
    SpriteRenderer m_eneSprite = default; //敵画像
    public int m_enemyHpMax; //敵最大体力
    public int m_enemyPower; //敵攻撃力
    [SerializeField]
    Text m_enemyName; //敵の名前

    public static int m_currentEHp; //現在の敵のHP

    public Text m_enemyHPNum; //敵体力の表示

    public Slider m_eHPSlider; //敵体力のバー

    public static int m_enemyAttack; //敵攻撃力

    public string[,] m_enemyMasterData; //そのクエストの敵データを二次元配列化

    public static int m_battleCountNum; //そのクエストにおける戦闘回数

    public int m_nextBattleReader; //現在の階層

    StringReader er;

    private bool m_kamishibai = false; //敵イラストを綺麗に入れ替えるため

    public static int m_enemyZokusei = 0; //0は火、1は水、2は木

    int m_enemyIllast = 0; //敵の画像番号

    //属性処理用受け値
    int m_takenDamageFire1 = 0;
    int m_takenDamageFire2 = 0;

    int m_takenDamageIce1 = 0;
    int m_takenDamageIce2 = 0;

    int m_takenDamageWood1 = 0;
    int m_takenDamageWood2 = 0;

    public static bool m_isBoss = false; //ボスフラグ

    void Awake()
    {
        m_QuestMasterID = PlayerPrefs.GetInt("Quest");
        PlayerPrefs.Save();

        m_eneSprite = GetComponent<SpriteRenderer>();

        m_kamishibai = false;

        er = new StringReader(m_csv[m_QuestMasterID].text);//今回のみそ。CVSを1次元配列として読み込んだ後、さらに２次元配列に落とし込む。

        m_battleCountNum = int.Parse(er.ReadLine()); //最初に読み込むのはそのステージでの戦闘回数


        if (m_battleCountNum == 1)
        {
            m_isBoss = true;
        }
        else
        {
            m_isBoss = false;
        }

        m_enemyMasterData = new string[m_battleCountNum, 6]; // ID, 名前 ,体力 ,攻撃力 ,属性 ,画像

        if (er != null)
        {

            for (var i = 0; i < m_battleCountNum; i++)
            {
                var line = er.ReadLine(); //2行目からはステージのデータを読み込む。
                string[] m_eStatus = line.Split(',');

                m_enemyMasterData[i, 0] = m_eStatus[0]; //そして見込んだデータは２次元配列化。
                m_enemyMasterData[i, 1] = m_eStatus[1];
                m_enemyMasterData[i, 2] = m_eStatus[2];
                m_enemyMasterData[i, 3] = m_eStatus[3];
                m_enemyMasterData[i, 4] = m_eStatus[4];
                m_enemyMasterData[i, 5] = m_eStatus[5];
            }
        }

        m_enemyName.text = m_enemyMasterData[0, 1];

        m_enemyHpMax = int.Parse(m_enemyMasterData[0, 2]);
        m_eHPSlider.maxValue = m_enemyHpMax;

        m_enemyPower = int.Parse(m_enemyMasterData[0, 3]);
        m_enemyAttack = m_enemyPower;

        m_enemyZokusei = int.Parse(m_enemyMasterData[0, 4]);

        m_enemyIllast = int.Parse(m_enemyMasterData[0, 5]);
        m_eneSprite.sprite = m_enemySprites[m_enemyIllast];

        m_currentEHp = m_enemyHpMax;
    }

    // Start is called before the first frame update
    void Start()
    {
        m_eHPSlider = GameObject.Find("EnemyHpSlider").GetComponent<Slider>();

        m_enemyHPNum.text = m_currentEHp.ToString();

    }

    // Update is called once per frame
    void Update()
    {

        m_eHPSlider.value = m_currentEHp;
        m_enemyHPNum.text = m_currentEHp.ToString();

        switch (m_enemyZokusei)
        {
            //属性によって受け値に倍率をかける。ついでに名前の色も変える
            case 0:

                m_enemyName.color = new Color(255f, 0f, 0f);

                m_takenDamageFire1 = PlayerPrefs.GetInt("RedS");
                m_takenDamageFire2 = PlayerPrefs.GetInt("RedC");

                m_takenDamageIce1 = PlayerPrefs.GetInt("BlueS") * 2;
                m_takenDamageIce2 = PlayerPrefs.GetInt("BlueC") * 2;

                m_takenDamageWood1 = PlayerPrefs.GetInt("GreenS") / 2;
                m_takenDamageWood2 = PlayerPrefs.GetInt("GreenC") / 2;
                break;

            case 1:

                m_enemyName.color = new Color(0f, 0f, 255f);

                m_takenDamageFire1 = PlayerPrefs.GetInt("RedS") / 2;
                m_takenDamageFire2 = PlayerPrefs.GetInt("RedC") / 2;

                m_takenDamageIce1 = PlayerPrefs.GetInt("BlueS");
                m_takenDamageIce2 = PlayerPrefs.GetInt("BlueC");

                m_takenDamageWood1 = PlayerPrefs.GetInt("GreenS") * 2;
                m_takenDamageWood2 = PlayerPrefs.GetInt("GreenC") * 2;
                break;

            case 2:

                m_enemyName.color = new Color(0f, 255f, 0f);

                m_takenDamageFire1 = PlayerPrefs.GetInt("RedS") * 2;
                m_takenDamageFire2 = PlayerPrefs.GetInt("RedC") * 2;

                m_takenDamageIce1 = PlayerPrefs.GetInt("BlueS") / 2;
                m_takenDamageIce2 = PlayerPrefs.GetInt("BlueC") / 2;

                m_takenDamageWood1 = PlayerPrefs.GetInt("GreenS");
                m_takenDamageWood2 = PlayerPrefs.GetInt("GreenC");
                break;

        }


        if (RedDropDestroy.fireAttackFlag == true)
        {
            m_currentEHp -= m_takenDamageFire1;
            RedDropDestroy.fireAttackFlag = false;
        }
        if (RedDropDestroy.fireMagicFlag == true)
        {
            m_currentEHp -= m_takenDamageFire2;
            RedDropDestroy.fireMagicFlag = false;
        }


        if (BlueDropDestroy.iceAttackFlag == true)
        {
            m_currentEHp -= m_takenDamageIce1;
            BlueDropDestroy.iceAttackFlag = false;
        }
        if (BlueDropDestroy.iceMagicFlag == true)
        {
            m_currentEHp -= m_takenDamageIce2;
            BlueDropDestroy.iceMagicFlag = false;
        }


        if (GreenDropDestroy.woodAttackFlag == true)
        {
            m_currentEHp -= m_takenDamageWood1;
            GreenDropDestroy.woodAttackFlag = false;
        }
        if (GreenDropDestroy.woodMagicFlag == true)
        {
            m_currentEHp -= m_takenDamageWood2;
            GreenDropDestroy.woodMagicFlag = false;
        }

        if (m_currentEHp <= 0 && m_kamishibai == false)
        {
            m_nextBattleReader++;
            m_kamishibai = true;
        }

        if (GameManager.turn == GameManager.Turn.NextBattleTurn)
        {
            if (m_nextBattleReader < m_battleCountNum)
            {
                m_enemyName.text = m_enemyMasterData[m_nextBattleReader, 1];

                m_enemyHpMax = int.Parse(m_enemyMasterData[m_nextBattleReader, 2]);
                m_eHPSlider.maxValue = m_enemyHpMax;

                m_enemyPower = int.Parse(m_enemyMasterData[m_nextBattleReader, 3]);
                m_enemyAttack = m_enemyPower;

                m_enemyZokusei = int.Parse(m_enemyMasterData[m_nextBattleReader, 4]);

                m_eneSprite.sprite = m_enemySprites[int.Parse(m_enemyMasterData[m_nextBattleReader, 5])];

                m_currentEHp = m_enemyHpMax;
                m_enemyHPNum.text = m_currentEHp.ToString();

                m_kamishibai = false;
                StartCoroutine(NextBattleSet());
            }/*
            else
            {
                GameManager.turn = GameManager.Turn.GameEnd;
                Debug.LogError("upd");
            }*/

            if(m_nextBattleReader == m_battleCountNum-1)
            {
                m_isBoss = true;
            }
        }

    }

    private void FixedUpdate() //ここじゃなきゃダメみてー。
    {
        if (GameManager.turn == GameManager.Turn.NextBattleTurn)
        {
            if (m_nextBattleReader == m_battleCountNum)
            {
                GameManager.turn = GameManager.Turn.GameEnd;
                //Debug.LogError("fxd");
            }
        }
    }

    public int EnemyCurrentAttack()
    {
        int x = m_enemyAttack;
        return x;
    }

    IEnumerator NextBattleSet()
    {
        yield return new WaitForSeconds(2.0f);
        GameManager.turn = GameManager.Turn.CleanUpTurn;
    }
}
