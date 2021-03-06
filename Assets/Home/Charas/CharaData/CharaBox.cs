using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaBox : MonoBehaviour
{
    public static List<int> m_GetCharaID = new List<int>(); //所持キャラのIDを保管する場所
    [SerializeField] GameObject[] m_Zukan = new GameObject[3]; //プレイアブルキャラのオブジェクト型マスター
    [SerializeField] List<GameObject> m_Drop = new List<GameObject>(); //泥キャラの取得元
    [SerializeField] LayoutGroup m_GL = default; //キャラボックス
    [SerializeField] Text m_MenuHeadText = default; //クリア時のソウル加算を表記するために

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
                x.SetActive(true);
                x.transform.parent = m_GL.transform;
                x.transform.localScale = m_Zukan[0].transform.localScale;
            }
            m_MenuHeadText.text = "所持ソウル: " + MenuManager.m_soul.ToString();
            GoHome.m_isBossDrop = false;
        }
    }
}
