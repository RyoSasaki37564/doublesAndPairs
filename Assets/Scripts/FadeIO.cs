using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIO : MonoBehaviour
{
    float m_speed = 0.005f; //染色速度
    float m_r, m_g, m_b, m_a; //色彩
    [SerializeField]Image m_image; //画像

    bool m_stopper = false;

    public static bool m_isNight = false; //背景に作用 BackGroundManager.cs

    // Start is called before the first frame update
    void Start()
    {
        m_r = m_image.color.r;
        m_g = m_image.color.g;
        m_b = m_image.color.b;
        m_a = m_image.color.a;
        m_isNight = false;
    }

    // Update is called once per frame
    void Update()
    {
        //黒くなるまで染めこむ
        if (NyuxLethalFazer.m_timePlus == true)
        {
            if (m_stopper == false)
            {
                Tobari();
                Coloring();
            }
            else
            {
                m_image.enabled = false;
                m_isNight = true;
            }
        }
        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_isNight = false;
            m_stopper = false;
            m_image.enabled = true;
            m_a = 0;
            Coloring();
        }
    }

    void Tobari()
    {
        m_image.enabled = true;
        m_r = 0;
        m_g = 0;
        m_b = 0;
        m_a += m_speed;
        if(m_a >= 1)
        {
            m_stopper = true;
        }
    }

    void Coloring()
    {
        m_image.color = new Color(m_r, m_g, m_b, m_a);
    }
}
