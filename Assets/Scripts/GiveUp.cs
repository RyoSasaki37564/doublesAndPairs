using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEditor;

public class GiveUp : MonoBehaviour
{
    //クエストをあきらめてホームに戻る！

    GoHome m_goHome = new GoHome();

    public static bool m_akirame = false; //スキルのリセッター

    public GameObject[] m_Obj; //戦闘開始時の全オブジェクト取得

    [SerializeField] GameObject m_dustBox = default; //戦闘終了時廃棄したいオブジェクトはこれを親にする。

    private void Start()
    {
        m_akirame = false;
        m_Obj = Resources.FindObjectsOfTypeAll<GameObject>();
    }

    public void Backer()
    {
        m_akirame = true;
        AbyssFazer.m_AbyssCanUse = false;
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
        m_goHome.GettingAllAndDestroy();
    }
}
