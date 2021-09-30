using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public Text timerText; //操作時間のUI
    [SerializeField]
    public float totalTime;
    int iii; //操作時間の打ち止め。－秒の表記封じ
    int seconds;

    int m_questBattleNowNum = 1; //現在の戦闘回数

    public enum Turn
    {
        InputTurn, //入力待ち
        PlayerTurn, //入力中ターン
        EnemyTurn, //敵の攻撃
        CleanUpTurn,  //残存ドロップの廃棄処理
        ResetTurn,  //ドロップ再配置
        NextBattleTurn, //次の戦闘の受け取りターン
        GameOut,  //ゲーム外状態。ゲームセットとゲームスタートの橋渡し役。
        GameEnd, //クエスト終了
    }
    public static Turn turn;

    public Text gst; //ゲームの始めと終わりを告げる。デフォではスタンバイとか書かれてる。
    public static bool gameSetFlag = true; //  ゲーム終了判定
    public static bool PlayTimeFlg = true; //操作時間カウントダウン用コルーチンを単発呼びするためのフラグ シーンのはじめか敵ターンにtrueを返す
    public static bool turnFlag = true; //　操作の可否

    [SerializeField] GameObject m_goalPanel = default; //リザルトの代わりにこのパネルを出す。

    /// <summary>前のターンの敵の最終体力</summary>
    public int m_resultEHp;

    // Start is called before the first frame update
    void Awake()
    {
        m_goalPanel.SetActive(false);

        iii = (int)totalTime; //カウントのストッパー

        gameSetFlag = true;
        turnFlag = true;
        PlayTimeFlg = true;
        StartCoroutine(GstUI());

        turn = Turn.GameOut;

    }

    private void Start()
    {
        gst.text = "バトル" + m_questBattleNowNum + "/" + Enemy.m_battleCountNum;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        switch (turn)
        {
            case Turn.InputTurn: // 操作待ちの状態
                turnFlag = true;
                totalTime = iii;
                seconds = (int)totalTime;
                timerText.text = "Play!";
                m_resultEHp = Enemy.m_currentEHp;
                Player.m_resultPHp = Player.m_currentPHp;
                PlayTimeFlg = true;
                //Debug.Log(turn);
                break;
            case Turn.PlayerTurn:// プレイヤーが動かしている時の状態
                gst.text = "";
                if (PlayTimeFlg)
                {
                    if (NyuxLethalFazer.m_timePlus == false)
                    {
                        StartCoroutine(PlayTime()); // updateでうごいてたからバグってた
                        PlayTimeFlg = false;
                    }
                    else
                    {
                        StartCoroutine(PlayTimePlus());
                        totalTime += 7;
                        PlayTimeFlg = false;
                    }
                }
                totalTime -= Time.deltaTime;
                seconds = (int)totalTime;
                timerText.text = "操作時間 : " + seconds.ToString();
                //Debug.Log(turn);
                break;
            case Turn.EnemyTurn: // 敵が攻撃してる状態
                PlayTimeFlg = true;
                timerText.text = "敵の攻撃！";
                break;

            case Turn.NextBattleTurn:
                PlayTimeFlg = false;
                if(turnFlag == true)
                {
                    m_questBattleNowNum++; //戦闘回数を1増やす。このフラグに包んでいるのはこのターンがアップデートで動いている間フレーム数分増えてしまうから。
                }
                turnFlag = false;
                gst.text = "ぶっとばし☆";
                seconds = iii;
                timerText.text = "操作時間 : " + seconds.ToString();
                break;

            case Turn.CleanUpTurn:
                gst.text = "バトル" + m_questBattleNowNum + "/" + Enemy.m_battleCountNum;
                break;
            case Turn.ResetTurn:
                Player.m_resultPHp = Player.m_currentPHp;
                m_resultEHp = Enemy.m_currentEHp;
                gst.text = "";
                timerText.text = "ぷれい！";
                //Debug.Log(turn);
                break;

            case Turn.GameOut:
                totalTime = iii;
                seconds = (int)totalTime;
                timerText.text = "PLAY!";
                //Debug.Log(turn);
                break;
            case Turn.GameEnd:
                m_goalPanel.SetActive(true);
                break;
            default:
                break;
        }

        if (Enemy.m_currentEHp <= 0)
        {
            gst.text = "いぇーい";
            timerText.text = "うぃん!";
            turn = Turn.NextBattleTurn;
        }

        if (Player.m_currentPHp <= 0)
        {
            gameSetFlag = false;
            gst.text = "ぶちころされました☆";
            timerText.text = "ぐぇえ！";
            m_goalPanel.SetActive(true);
            turn = Turn.GameOut;
        }

        if (turn == Turn.GameOut) //ゲーム外ターン。ゲーム終了処理をしたのちインプットに戻るだけのターン。
        {
            turn = Turn.InputTurn;
        }
    }
    public static void SetTurn(Turn t)
    {
        if (turn != Turn.EnemyTurn) // エネミーターン以外の時
        {
            turn = t;
        }
    }

    IEnumerator GstUI()
    {
        yield return new WaitForSeconds(2.0f);
        gst.text = "";
    }

    IEnumerator PlayTime()
    {
        yield return new WaitForSeconds(totalTime);
        if (totalTime <= 0)
        {
            turnFlag = false;
            turn = Turn.EnemyTurn;
        }
        else
        {
            yield break;
        }
    }

    IEnumerator PlayTimePlus()
    {
        yield return new WaitForSeconds(totalTime + 7);
        if (totalTime <= 0)
        {
            turnFlag = false;
            turn = Turn.EnemyTurn;
        }
        else
        {
            yield break;
        }
    }
}
