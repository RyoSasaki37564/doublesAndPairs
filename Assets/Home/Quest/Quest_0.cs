using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Quest_0 : MonoBehaviour
{
    [SerializeField] GameObject m_QuestPanel = default;

    private void Start()
    {
        m_QuestPanel.SetActive(false);
    }

    public void QuestStart()
    {
        m_QuestPanel.SetActive(true);
    }
}
