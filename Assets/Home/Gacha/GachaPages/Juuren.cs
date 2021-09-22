using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Juuren : Hikimasu
{
    public override void Gacha()
    {
        for(var i = 0; i < 11; i++)
        {
            base.Gacha();
        }
    }
}
