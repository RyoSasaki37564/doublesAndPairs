using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NowLoadingBreak : MonoBehaviour
{
    private void Bye()
    {
        //使用制限系スキル状態はここで初期化
        AbyssFazer.m_AbyssCanUse = false;
        NyuxFazer.m_NyuxCanUse = false;
        Destroy (this.gameObject);
    }
}
