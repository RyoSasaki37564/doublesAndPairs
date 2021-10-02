using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlashFader : MonoBehaviour
{
    //演出終了後消えるまでは透明化
    [SerializeField]SpriteRenderer m_spr;

    private void Update()
    {
        if(Charge.m_chargeState == Charge.ChargeEnsyutu.EndState)
        {
            Destroy(this.gameObject);
        }
    }

    //終了時にFadeIOにフラグを送る。
    public void SlashEnd()
    {
        Charge.m_chargeState = Charge.ChargeEnsyutu.AttackState;
        m_spr.color = new Color(0, 0, 0, 0);
    }
}
