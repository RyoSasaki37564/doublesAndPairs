using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class PrimaryDefault : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject m_Parmanent = default; //パーマネントを格納

    [SerializeField] GameObject m_ParmanentPos = default; //パーマネントマーク展開の位置

    [SerializeField] GameObject m_skillPannel = default; //スキル状態表示パネル
    [SerializeField] Text m_charaName = default;
    [SerializeField] Text m_skillFaze = default;
    [SerializeField] Text m_skillSetumei = default;
    [SerializeField] Text m_CanUsing = default;

    bool m_parmanentChargeFlg = false;

    [SerializeField] GameObject m_pannelPos = default;//パネル表示位置

    // Start is called before the first frame update
    private void Start()
    {
        m_skillPannel.SetActive(false);
        m_parmanentChargeFlg = true;
    }

    public virtual void Parmanent()
    {
        if (GameManager.gameSetFlag)
        {
            if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
            {
                if (m_parmanentChargeFlg == true)
                {

                    Instantiate(m_Parmanent, m_ParmanentPos.transform.position, m_ParmanentPos.transform.rotation);
                    m_parmanentChargeFlg = false;
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
        m_skillFaze.text = "フェイズ : PrimaryDefault";
        if (m_parmanentChargeFlg == true)
        {
            m_CanUsing.text = "使用可能";
        }
        else
        {
            m_CanUsing.text = "使用中";
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_skillPannel.SetActive(false);
    }

}