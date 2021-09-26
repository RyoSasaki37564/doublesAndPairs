using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESys : MonoBehaviour
{
    [SerializeField] GameObject m_SESystem;

    // Start is called before the first frame update
    void Start()
    {
        m_SESystem.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        if(GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn ||
            GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            m_SESystem.SetActive(true);
        }
        else
        {
            m_SESystem.SetActive(false);
        }
    }
}
