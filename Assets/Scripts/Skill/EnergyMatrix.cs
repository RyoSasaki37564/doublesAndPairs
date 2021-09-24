using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyMatrix : MonoBehaviour
{
    [SerializeField] GameObject[] m_energys = new GameObject[2]; //ドロップを格納

    [SerializeField] GameObject[] m_generatePos = new GameObject[6]; //生成位置

    int m_hole; //生成位置決定用乱数

    int m_tama; //生成ドロップ決定用乱数

    public virtual void Generate()
    {
        if (GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            m_hole = Random.Range(0, m_generatePos.Length);
            m_tama = Random.Range(0, m_energys.Length);

            Instantiate(m_energys[m_tama], m_generatePos[m_hole].transform.position, m_generatePos[m_hole].transform.rotation);

        }
    }
}
