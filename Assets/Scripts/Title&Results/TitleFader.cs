using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TitleFader : MonoBehaviour
{
    [SerializeField] float m_speed = 0.005f; //染色速度
    float m_r, m_g, m_b;
    float m_a = 255f; //色彩
    [SerializeField] Image m_image; //画像

    bool m_stopper = false;

    // Start is called before the first frame update
    void Start()
    {
        m_r = m_image.color.r;
        m_g = m_image.color.g;
        m_b = m_image.color.b;
        m_a = m_image.color.a;
    }

    // Update is called once per frame
    void Update()
    {
        if (m_stopper == false)
        {
            Yoake();
            Coloring();
        }
        else
        {
            m_image.enabled = false;
        }
    }

    void Yoake()
    {
        m_image.enabled = true;
        m_r = 0;
        m_g = 0;
        m_b = 0;
        m_a -= m_speed;
        if (m_a == 0)
        {
            m_stopper = true;
        }
    }

    void Coloring()
    {
        m_image.color = new Color(m_r, m_g, m_b, m_a);
    }
}
