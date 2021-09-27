using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZukanModeOn : MonoBehaviour
{
    [SerializeField] GameObject m_Zukan = default; //図鑑
    bool m_flg = false;

    [SerializeField] GameObject m_charasStats = default; //キャラステ表
    
    public void ZukanMode()
    {
        if(m_flg == false)
        {
            m_Zukan.SetActive(true);
            m_flg = true;
        }
        else
        {
            m_charasStats.SetActive(false);
            m_Zukan.SetActive(false);
            m_flg = false;
        }
        
    }

}
