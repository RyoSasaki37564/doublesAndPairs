using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class LetsGoQuest : MonoBehaviour
{
    [SerializeField] GameObject m_HomeScene = default; //ホームの始祖オブジェクト

    [SerializeField] GameObject m_kakuninPanel = default; //「クエストに行きますか」のパネル

    [SerializeField] GameObject m_NowLoading; //最後尾背景

    public void GoQuest()
    {
        m_NowLoading.SetActive(true);
        m_kakuninPanel.SetActive(false);
        m_HomeScene.SetActive(false); 
        SceneManager.LoadScene("MainGame", LoadSceneMode.Additive);
    }

}
