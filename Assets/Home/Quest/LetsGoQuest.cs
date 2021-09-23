using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsGoQuest : MonoBehaviour
{
    [SerializeField] GameObject m_HomeScene = default;

    [SerializeField] GameObject m_kakuninPanel = default;

    public void GoQuest()
    {
        UserCharaIcon.m_partyNum = 0;
        m_kakuninPanel.SetActive(false);
        SceneManager.LoadScene("MainGame", LoadSceneMode.Additive);
        m_HomeScene.SetActive(false);
    }
}
