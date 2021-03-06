using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public abstract class PrimaryDefault : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] GameObject m_Parmanent = default; //パーマネントを格納

    [SerializeField] GameObject m_ParmanentPos = default; //パーマネントマーク展開の位置
    Transform m_defaultPos; //初期配置

    [SerializeField] GameObject m_skillPannel = default; //スキル状態表示パネル
    [SerializeField] Text m_charaName = default;
    [SerializeField] Text m_skillFaze = default;
    [SerializeField] Text m_skillSetumei = default;
    [SerializeField] Text m_CanUsing = default;

    bool m_parmanentChargeFlg = false;

    [SerializeField] GameObject m_pannelPos = default;//パネル表示位置

    static int m_parmanentNum = 0;

    Vector2 m_firstParmanentPos;

    [SerializeField] bool m_ParmaOrDispo = false; //永続か使い捨て。false = 永続。

    // Start is called before the first frame update
    private void Start()
    {
        m_parmanentNum = 0;
        m_skillPannel.SetActive(false);
        m_parmanentChargeFlg = true;
        m_firstParmanentPos = m_ParmanentPos.transform.position;
        Debug.Log(m_parmanentNum);
    }

    private void Update()
    {
        if (GameManager.turn == GameManager.Turn.GameEnd)
        {
            m_ParmanentPos.transform.position = m_firstParmanentPos;
        }
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
                    m_parmanentNum++;
                    m_parmanentChargeFlg = false;
                    if (m_parmanentNum < 3)
                    {
                        m_ParmanentPos.transform.position = new Vector2(m_ParmanentPos.transform.position.x,
                            m_ParmanentPos.transform.position.y - 0.8f);
                    }
                    else
                    {
                        m_ParmanentPos.transform.position = new Vector2(m_firstParmanentPos.x-0.7f, m_firstParmanentPos.y-0.8f*(m_parmanentNum-3));
                    }
                }
            }
        }

        m_skillPannel.SetActive(false);
    }

    public virtual void StatusPanneler(string name, string setu)
    {
        if(m_charaName != null)
        {
            m_charaName.text = name;

        }
        if(m_skillSetumei != null)
        {
            m_skillSetumei.text = setu;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        m_skillPannel.SetActive(true);
        m_skillPannel.transform.position = m_pannelPos.transform.position;
        m_skillFaze.text = "フェイズ : PrimaryDefault";
        if (m_parmanentChargeFlg == true)
        {
            m_CanUsing.text = "使用可能";
            m_CanUsing.color = Color.black;
        }
        else
        {
            if(m_ParmaOrDispo == true)
            {
                m_CanUsing.text = "使用不可";
                m_CanUsing.color = Color.red;
            }
            else
            {
                m_CanUsing.text = "使用中";
                m_CanUsing.color = Color.green;
            }
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        m_skillPannel.SetActive(false);
    }

}