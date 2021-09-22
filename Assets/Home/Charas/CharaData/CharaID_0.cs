using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharaID_0 : UserCharaIcon
{
    bool m_partyIO = false;

    [SerializeField]int[] m_status = { 1700, 10, 12, 8, 8, 12, 9, 0 }; //このキャラのステ

    public override void PartyIO()
    {
        if(m_partyIO == false)
        {
            //メンバー選択したらステを足す
            PartyParamator.m_hp = PartyParamator.m_hp + m_status[0];
            PlayerPrefs.SetInt("PlayerHp", PartyParamator.m_hp);

            PartyParamator.m_fireButuri = PartyParamator.m_fireButuri + m_status[1];
            PlayerPrefs.SetInt("RedS", PartyParamator.m_fireButuri);

            PartyParamator.m_fireMahou = PartyParamator.m_fireMahou + m_status[2];
            PlayerPrefs.SetInt("RedC", PartyParamator.m_fireMahou);

            PartyParamator.m_iceButuri = PartyParamator.m_iceButuri + m_status[3];
            PlayerPrefs.SetInt("BlueS", PartyParamator.m_iceButuri);

            PartyParamator.m_iceMahou = PartyParamator.m_iceMahou + m_status[4];
            PlayerPrefs.SetInt("BlueC", PartyParamator.m_iceMahou);

            PartyParamator.m_woodButuri = PartyParamator.m_woodButuri + m_status[5];
            PlayerPrefs.SetInt("GreenS", PartyParamator.m_woodButuri);

            PartyParamator.m_woodMahou = PartyParamator.m_woodMahou + m_status[6];
            PlayerPrefs.SetInt("GreenC", PartyParamator.m_woodMahou);

            PlayerPrefs.Save();

            PartyParamator.m_usingCharaID.Add(m_status[7]);

            m_partyIO = true;
            base.PartyIO();
        }
        else
        {
            PartyParamator.m_hp = PartyParamator.m_hp - m_status[0];
            PlayerPrefs.SetInt("PlayerHp", PartyParamator.m_hp);

            PartyParamator.m_fireButuri = PartyParamator.m_fireButuri - m_status[1];
            PlayerPrefs.SetInt("RedS", PartyParamator.m_fireButuri);

            PartyParamator.m_fireMahou = PartyParamator.m_fireMahou - m_status[2];
            PlayerPrefs.SetInt("RedC", PartyParamator.m_fireMahou);

            PartyParamator.m_iceButuri = PartyParamator.m_iceButuri - m_status[3];
            PlayerPrefs.SetInt("BlueS", PartyParamator.m_iceButuri);

            PartyParamator.m_iceMahou = PartyParamator.m_iceMahou - m_status[4];
            PlayerPrefs.SetInt("BlueC", PartyParamator.m_iceMahou);

            PartyParamator.m_woodButuri = PartyParamator.m_woodButuri - m_status[5];
            PlayerPrefs.SetInt("GreenS", PartyParamator.m_woodButuri);

            PartyParamator.m_woodMahou = PartyParamator.m_woodMahou - m_status[6];
            PlayerPrefs.SetInt("GreenC", PartyParamator.m_woodMahou);

            PlayerPrefs.Save();

            PartyParamator.m_usingCharaID.Remove(m_status[7]);

            m_partyIO = false;
            base.PartyIO();
        }

    }
}
