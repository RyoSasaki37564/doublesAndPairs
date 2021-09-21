using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UserCharaIcon : MonoBehaviour
{
    bool m_isInParty = false; //パーティメンバーかどうか

    [SerializeField] LayoutGroup m_charaBox = default; //ボックス

    [SerializeField] LayoutGroup m_party = default; //パーティ

    static int m_partyNum = 0;

    public void PartyIO()
    {
        if(m_isInParty == false && m_partyNum < 6)
        {
            this.gameObject.transform.SetParent(m_party.transform);
            m_partyNum++;
            m_isInParty = true;
        }

        else if(m_isInParty == true)
        {
            this.gameObject.transform.SetParent(m_charaBox.transform);
            m_partyNum--;
            m_isInParty = false;
        }
    }

}
