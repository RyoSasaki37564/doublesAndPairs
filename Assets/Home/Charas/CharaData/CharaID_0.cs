using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaID_0 : UserCharaIcon
{
    bool m_partyIO = false;

    int[] m_status = { 1700, 10, 12, 8, 8, 12, 9 }; //このキャラのステ

    PartyParamator m_party = new PartyParamator();

    public override void PartyIO()
    {

        if(m_partyIO == false)
        {
            m_party.m_hp = m_party.m_hp + m_status[0];
            PlayerPrefs.SetInt("PlayerHp",m_party.m_hp);

            m_party.m_fireButuri = m_party.m_fireButuri + m_status[1];
            PlayerPrefs.SetInt("RedS", m_party.m_fireButuri);

            m_party.m_fireMahou = m_party.m_fireMahou + m_status[2];
            PlayerPrefs.SetInt("RedC", m_party.m_fireMahou);

            m_party.m_iceButuri = m_party.m_iceButuri + m_status[3];
            PlayerPrefs.SetInt("BlueS", m_party.m_iceButuri);

            m_party.m_iceMahou = m_party.m_iceMahou + m_status[4];
            PlayerPrefs.SetInt("BlueC", m_party.m_iceMahou);

            m_party.m_woodButuri = m_party.m_woodButuri + m_status[5];
            PlayerPrefs.SetInt("GreenS", m_party.m_woodButuri);

            m_party.m_woodMahou = m_party.m_woodMahou + m_status[6];
            PlayerPrefs.SetInt("GreenC", m_party.m_woodMahou);

            PlayerPrefs.Save();

            m_partyIO = true;
        }
        else
        {
            m_party.m_hp = m_party.m_hp - m_status[0];
            PlayerPrefs.SetInt("PlayerHp", m_party.m_hp);

            m_party.m_fireButuri = m_party.m_fireButuri - m_status[1];
            PlayerPrefs.SetInt("RedS", m_party.m_fireButuri);

            m_party.m_fireMahou = m_party.m_fireMahou - m_status[2];
            PlayerPrefs.SetInt("RedC", m_party.m_fireMahou);

            m_party.m_iceButuri = m_party.m_iceButuri - m_status[3];
            PlayerPrefs.SetInt("BlueS", m_party.m_iceButuri);

            m_party.m_iceMahou = m_party.m_iceMahou - m_status[4];
            PlayerPrefs.SetInt("BlueC", m_party.m_iceMahou);

            m_party.m_woodButuri = m_party.m_woodButuri - m_status[5];
            PlayerPrefs.SetInt("GreenS", m_party.m_woodButuri);

            m_party.m_woodMahou = m_party.m_woodMahou - m_status[6];
            PlayerPrefs.SetInt("GreenC", m_party.m_woodMahou);

            PlayerPrefs.Save();

            m_partyIO = false;
        }

        base.PartyIO();
    }
}
