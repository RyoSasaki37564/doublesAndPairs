using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class Juuren : Hikimasu
{
    //10+1連ガチャの基本形。
    public override void Gacha()
    {
        if (MenuManager.m_soul >= 30)
        {

            for (var i = 0; i < 10; i++)
            {
                base.Gacha();
            }
            MenuManager.m_soul += 3;
            base.Gacha();
        }
    }
}
