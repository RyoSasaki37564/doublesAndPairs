using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GoHome : MonoBehaviour
{
    [SerializeField] Text m_topickTEXT = default; //戦闘終了後に出てくるトピック
    string[] m_kaibunshos = { "にゃん(=・ω・=)\n" + "動物大好き。", "神も仏もいない現代において、非力なる人類はただ祈ることすらできないんだ!",
        "お風呂上りに爪切りすると少し柔らかいぞ。", "佐々木涼は朝でもカップラーメンとか食べちゃうタイプの人。", "エナジードリンクはモンスターの緑が世界一美味である。", 
    "パズ〇ラではない。", "エナジーマトリックスは効果のわりに見た目がちょっと怖いのを気にしているぞ！", "ぷよ〇よではない。", "ニュクスはああ見えて毎日朝シャンしてる。", 
    "ソウルを使うと寿命が減るぞ。1個１年分だって。", "900億円くらい欲しいぞ！", "実はビームが出せる。"};

    public GameObject[] m_Obj; //戦闘開始時の全オブジェクト取得

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
        GettingAllAndDestroy();

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

    public void GettingAllAndDestroy()
    {
        SceneManager.UnloadSceneAsync("MainGame");
        Debug.Log("foo");
        //ヒエラルキーからホームの始祖オブジェクトを持ってきてアクティブ化
        if (m_Obj != null)
        {
            foreach (var home in m_Obj)
            {
#if UNITY_EDITOR
                if (!AssetDatabase.GetAssetOrScenePath(home).Contains(".unity"))
                {
                    continue;
                }

#endif

                if (home.name == "Home")
                {
                    home.SetActive(true);
                }

            }
            if (m_dustBox != null)
            {
                Destroy(m_dustBox);
            }
        }
    }
}
