using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Sakujo : MonoBehaviour
{
   public void DataDestroy()
    {
        UserCharaIcon.m_partyNum = 0;
        CharaID.m_usingCharaID.Clear();
        SceneManager.LoadScene("Title");
    }
}
