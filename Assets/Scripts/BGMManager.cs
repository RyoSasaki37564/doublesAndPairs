using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BGMManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_jukeBoxes = new GameObject[5]; //ノーマル、ボス、クリア×3(ひとつはパーティクル)。

    public enum Ongen
    {
        Nomal,
        Boss,
        Clear,
    }

    Ongen m_sounds;

    private void Start()
    {
         m_sounds = Ongen.Nomal;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        /*if(GameManager.turn == GameManager.Turn.GameEnd && Player.m_currentPHp > 0)
        {
            m_sounds = Ongen.Clear;
        }*/
        if (Enemy.m_isBoss == true)//else if(Enemy.m_isBoss == true)
        {
            m_sounds = Ongen.Boss;
        }

        switch (m_sounds)
        {
            case Ongen.Nomal:
                m_jukeBoxes[0].SetActive(true);
                m_jukeBoxes[1].SetActive(false);
                m_jukeBoxes[2].SetActive(false);
                m_jukeBoxes[3].SetActive(false);
                m_jukeBoxes[4].SetActive(false);
                break;
            case Ongen.Boss:
                m_jukeBoxes[0].SetActive(false);
                m_jukeBoxes[2].SetActive(false);
                m_jukeBoxes[3].SetActive(false);
                m_jukeBoxes[4].SetActive(false);
                StartCoroutine(SetBossBGM());
                break;
            case Ongen.Clear:
                m_jukeBoxes[2].SetActive(true);
                m_jukeBoxes[3].SetActive(true);
                m_jukeBoxes[4].SetActive(true);
                m_jukeBoxes[0].SetActive(false);
                m_jukeBoxes[1].SetActive(false);
                //StartCoroutine(SetClear());
                break;
        }

    }

    IEnumerator SetBossBGM()
    {
        yield return new WaitForSeconds(2f);
        m_jukeBoxes[1].SetActive(true);
    }

    IEnumerator SetClear()
    {
        yield return new WaitForSeconds(0.6f);

        m_jukeBoxes[2].SetActive(true);
        m_jukeBoxes[3].SetActive(true);
        m_jukeBoxes[4].SetActive(true);
    }
}
