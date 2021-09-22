using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsGoQuest : MonoBehaviour
{
    public void GoQuest()
    {
        UserCharaIcon.m_partyNum = 0;
        SceneManager.LoadScene("MainGame");
    }
}
