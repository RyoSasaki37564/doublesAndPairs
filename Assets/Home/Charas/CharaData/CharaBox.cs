using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaBox : MonoBehaviour
{
    public static List<int> m_GetCharaID = new List<int>(); //所持キャラのIDを保管する場所
    [SerializeField] GameObject[] m_Zukan = new GameObject[3]; //プレイアブルキャラのオブジェクト型マスター
    [SerializeField] List<GameObject> m_Drop = new List<GameObject>(); //プレイアブルキャラのオブジェクト型マスター
    [SerializeField] LayoutGroup m_GL = default; //キャラボックス

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < m_GetCharaID.Count; i++)
        {
            int n = m_GetCharaID[i];
            var x = Instantiate(m_Zukan[n]);
            x.transform.SetParent(m_GL.transform);
            x.transform.localScale = m_Zukan[0].transform.localScale;
            x.SetActive(true);
        }
    }

    // Update is called once per frame
    void Update()
    {
        //ボスドロップキャラの取得
        if(GoHome.m_isBossDrop == true)
        {
            int n = PlayerPrefs.GetInt("Quest");
            if (m_Drop[n] != null)
            {
                var x = Instantiate(m_Drop[n]);
                x.transform.SetParent(m_GL.transform);
                x.transform.localScale = m_Zukan[0].transform.localScale;
                x.SetActive(true);
            }
            GoHome.m_isBossDrop = false;
        }
    }
}
