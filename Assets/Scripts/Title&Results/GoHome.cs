using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GoHome : MonoBehaviour
{
    [SerializeField] Text m_topickTEXT = default; //戦闘終了後に出てくるトピック
    string[] m_kaibunshos = { "にゃん(=・ω・=)" + "動物大好き。", "神も仏もいない現代社会において、非力なる人類はただ祈ることしかできないんだ。",
        "お風呂上りに爪切りすると少し柔らかいぞ。", "佐々木は朝でもカップラーメンとか食べちゃう派", "エナジードリンクはモンスターの緑が世界一美味なんだ。", 
    "パズ〇ラではない。", "エナジーマトリックスは効果のわりに見た目がちょっと怖いのを気にしているぞ。"};

    GameObject[] m_Obj; //戦闘開始時の全オブジェクト取得

    public static bool m_isBossDrop = false;

    [SerializeField] GameObject m_dustBox = default; //戦闘終了時廃棄したいオブジェクトはこれを親にする。

    private void Start()
    {
        int n = Random.Range(0, m_kaibunshos.Length);
        m_topickTEXT.text = m_kaibunshos[n];

        m_Obj = Resources.FindObjectsOfTypeAll<GameObject>();
    }

    public void BattleEnded()
    {
        SceneManager.UnloadSceneAsync("MainGame");
        Debug.Log("foo");
        //ヒエラルキーからホームの始祖オブジェクトを持ってきてアクティブ化
        foreach(var home in m_Obj)
        {
#if UNITY_EDITOR
            if(!AssetDatabase.GetAssetOrScenePath(home).Contains(".unity"))
            {
                continue;
            }
#endif
            if(home.name == "Home")
            {
                home.SetActive(true);
            }
        }
        Destroy(m_dustBox);

        if(Player.m_currentPHp > 0)
        {
            m_isBossDrop = true;
            MenuManager.m_soul += 10;
        }
        else
        {
            m_isBossDrop = false;
        }

    }
}
