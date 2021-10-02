using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FadeIO : MonoBehaviour
{
    float m_speed = 0.005f; //染色速度
    float m_r, m_g, m_b, m_a; //色彩
    [SerializeField]Image m_image; //画像

    bool m_blackStopper = false;
    bool m_whiteStopper = false;

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
        if (GameManager.m_timeLange == GameManager.TimeLange.Plus7)
        {
            if (m_blackStopper == false)
            {
                Tobari();
                Coloring();
            }
            else
            {
                if(m_isNight == false)
                {
                    Clearing();
                }
                m_isNight = true;
            }
        }

        if (Charge.m_chargeState == Charge.ChargeEnsyutu.AttackState)
        {
            if (m_whiteStopper == false)
            {
                Byakkoh();
                Coloring();
            }
            else
            {
                if(Charge.m_chargeState != Charge.ChargeEnsyutu.EndState)
                {
                    Clearing();
                }
                Charge.m_chargeState = Charge.ChargeEnsyutu.EndState;
            }
        }

        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_isNight = false;
            m_blackStopper = false;
            m_whiteStopper = false;
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
        if (m_a >= 1)
        {
            m_blackStopper = true;
        }
    }

    void Byakkoh()
    {
        m_image.enabled = true;
        m_r = 255;
        m_g = 255;
        m_b = 255;
        m_a += m_speed * 0.8f;
        if (m_a >= 1)
        {
            m_whiteStopper = true;
        }
    }

    void Clearing() //透明化
    {
        m_r = 0;
        m_g = 0;
        m_b = 0;
        m_a = 0;
        Coloring();
    }

    void Coloring()
    {
        m_image.color = new Color(m_r, m_g, m_b, m_a);
    }
}
