using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public abstract class Skill : MonoBehaviour
{
    [SerializeField] GameObject[] m_fazerSkills = new GameObject[3]; //フェイザーを格納
    [SerializeField] GameObject m_skillEffectPosition = default; //生成位置
    [SerializeField] Text m_skillBottunText = default; //スキルボタンの文字

    bool m_skillChargeFlg = false;

    public enum Faze
    {
        firstFazer, //初期フェイザー
        secondFazer, //一段階解放
        lethalFazer, //最終段階解放
    }

    public static Faze m_faze;

    // Start is called before the first frame update
    private void Start()
    {
        m_skillChargeFlg = true;
        m_skillBottunText.text = m_faze.ToString();
    }
    public virtual void Fazer()
    {
        if (m_skillChargeFlg == true)
        {
            switch (m_faze)
            {
                case Faze.firstFazer:
                    m_skillBottunText.text = m_faze.ToString();
                    Instantiate(m_fazerSkills[0], m_skillEffectPosition.transform.position, m_skillEffectPosition.transform.rotation);
                    m_skillChargeFlg = false;
                    m_skillBottunText.text = "使用不可";
                    break;
                case Faze.secondFazer:
                    m_skillBottunText.text = m_faze.ToString();
                    Instantiate(m_fazerSkills[1], m_skillEffectPosition.transform.position, m_skillEffectPosition.transform.rotation);
                    m_skillChargeFlg = false;
                    m_skillBottunText.text = "使用不可";
                    break;
                case Faze.lethalFazer:
                    m_skillBottunText.text = m_faze.ToString();
                    Instantiate(m_fazerSkills[2], m_skillEffectPosition.transform.position, m_skillEffectPosition.transform.rotation);
                    m_skillChargeFlg = false;
                    m_skillBottunText.text = "使用不可";
                    break;
                default:
                    break;
            }
        }
        else
        {
            m_skillBottunText.text = "使用不可";
        }
    }
}
