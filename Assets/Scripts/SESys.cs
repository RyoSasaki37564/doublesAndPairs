using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SESys : MonoBehaviour
{
    [SerializeField] GameObject[] m_SESystem = new GameObject[3]; //0:ドロップデストロイ, 1:ウィニング, 2:エネミーアタック
    //0は現在使用していない。効果音はドロップデストロイに任せている。

    bool m_wSEFlg = false;

    // Start is called before the first frame update
    void Start()
    {
        m_SESystem[0].SetActive(false);
        m_SESystem[1].SetActive(false);
        m_SESystem[2].SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

        //ウィニングファンファーレ
        if (Enemy.m_currentEHp <= 0 && m_wSEFlg == false)
        {
            m_SESystem[1].SetActive(true);
            m_wSEFlg = true;
        }
        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_SESystem[1].SetActive(false);
            m_wSEFlg = false;
        }

        //エネミーアタック
        if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            m_SESystem[2].SetActive(true);
            StartCoroutine(MutiReset());
        }
    }

    IEnumerator MutiReset()
    {
        yield return new WaitForSeconds(1.5f);
        m_SESystem[2].SetActive(false);
    }
}
