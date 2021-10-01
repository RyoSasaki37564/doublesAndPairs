using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetsGoQuest : MonoBehaviour
{
    [SerializeField] GameObject m_HomeScene = default; //ホームの始祖オブジェクト

    [SerializeField] GameObject m_kakuninPanel = default; //「クエストに行きますか」のパネル

    [SerializeField] GameObject m_NowLoadingBack; //最後尾背景

    [SerializeField] GameObject m_NowLosdingCanvas = default; //ローディング文字キャンヴァス


    public void GoQuest()
    {
        m_NowLoadingBack.SetActive(true);
        var x =  Instantiate(m_NowLosdingCanvas);
        x.transform.parent = m_NowLoadingBack.transform;
        m_kakuninPanel.SetActive(false);
        m_HomeScene.SetActive(false); 
        SceneManager.LoadScene("MainGame", LoadSceneMode.Additive);
    }

}
