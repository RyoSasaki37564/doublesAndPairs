using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LetsGoQuest : MonoBehaviour
{
    public void GoQuest()
    {
        SceneManager.LoadScene("MainGame");
    }
}
