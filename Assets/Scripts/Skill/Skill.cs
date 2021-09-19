using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class Skill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject[] m_fazerSkills = new GameObject[3]; //フェイザーを格納
    [SerializeField] GameObject m_skillEffectPosition = default; //生成位置

    [SerializeField] GameObject m_SpecialPos = default; //特殊スキル生成位置

    [SerializeField] GameObject m_skillPannel = default; //スキル状態表示パネル
    [SerializeField] Text m_charaName = default;
    [SerializeField] Text m_skillFaze = default;
    [SerializeField] Text m_skillSetumei = default;
    [SerializeField] Text m_CanUsing = default;

    bool m_skillChargeFlg = false;

    public static bool m_healFlg = false;

    [SerializeField] GameObject m_pannelPos = default;//パネル表示位置

    public enum Faze
    {
        First, //初期フェイザー
        Second, //第二段階解放
        Lethal, //最終段階解放
    }

    public Faze m_faze;

    // Start is called before the first frame update
    private void Start()
    {
        m_skillPannel.SetActive(false);
        m_skillChargeFlg = true;
        m_faze = Faze.First;
    }

    public virtual void Fazer()
    {
        if (GameManager.gameSetFlag)
        {
            if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
            {
                if (m_skillChargeFlg == true)
                {
                    switch (m_faze)
                    {
                        case Faze.First:
                            Instantiate(m_fazerSkills[0], m_skillEffectPosition.transform.position, m_skillEffectPosition.transform.rotation);
                            m_faze = Faze.Second;
                            m_skillFaze.text = m_faze.ToString();
                            //m_skillChargeFlg = false;
                            break;
                        case Faze.Second:
                            Instantiate(m_fazerSkills[1], m_skillEffectPosition.transform.position, m_skillEffectPosition.transform.rotation);
                            m_faze = Faze.Lethal;
                            //m_skillChargeFlg = false;
                            break;
                        case Faze.Lethal:
                            Instantiate(m_fazerSkills[2], m_SpecialPos.transform.position, m_SpecialPos.transform.rotation);
                            m_skillChargeFlg = false;
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        m_skillPannel.SetActive(false);
    }

    public virtual void StatusPanneler(string name, string setu)
    {
        m_charaName.text = name;
        m_skillSetumei.text = setu;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_skillPannel.SetActive(true);
        m_skillPannel.transform.position = m_pannelPos.transform.position;
        m_skillFaze.text = "フェイズ : " + m_faze.ToString();
        if (m_skillChargeFlg == true)
        {
            m_CanUsing.text = "使用可能";
        }
        else
        {
            m_CanUsing.text = "現在使用不可";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_skillPannel.SetActive(false);
    }

}
