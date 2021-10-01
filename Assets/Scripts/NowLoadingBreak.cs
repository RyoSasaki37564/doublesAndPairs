using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowLoadingBreak : MonoBehaviour
{
    private void Bye()
    {
        //使用制限系スキルの状態はここで初期化
        AbyssFazer.m_AbyssCanUse = false;
        NyuxFazer.m_NyuxCanUse = false;
        RicoreFazer.m_RicoreCanUse = false;
        Destroy (this.gameObject);
    }
}
