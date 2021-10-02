using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashFader : MonoBehaviour
{
    //演出終了後は透明化
    [SerializeField]SpriteRenderer m_spr;

    
    //終了時にFadeIOにフラグを送る。
    public void SlashEnd()
    {
        Charge.m_chargeState = Charge.ChargeEnsyutu.AttackState;
        m_spr.color = new Color(0, 0, 0, 0);
    }
}
