using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KakuteiGacha : Hikimasu
{
    [SerializeField] GameObject m_thisGacha = default; //確定ガチャは１度きり
    public override void Gacha()
    {
        if (MenuManager.m_soul >= 30)
        {

            for (var i = 0; i < 10; i++)
            {
                base.Gacha();
            }
            MenuManager.m_soul += 3;
            base.SSRKakutei();

            Destroy(m_thisGacha);

        }
    }
}
