using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Quest_0 : MonoBehaviour
{
    [SerializeField] GameObject m_QuestPanel = default;

    [SerializeField] Text m_alart = default;

    private void Start()
    {
        m_QuestPanel.SetActive(false);
        m_alart.text = "";
    }

    public void QuestStart()
    {
        if(UserCharaIcon.m_partyNum != 0)
        {
            m_alart.text = "";
            m_QuestPanel.SetActive(true);
        }
        else
        {
            m_alart.text = "パーティメンバーを選択してください。";
            StartCoroutine(TextReset());
        }
    }

    IEnumerator TextReset()
    {
        yield return new WaitForSeconds(1f);
        m_alart.text = "";
    }
}
