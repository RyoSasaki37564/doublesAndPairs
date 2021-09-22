using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOff : MonoBehaviour
{
    //リザルト画面消すぜ。
    //このスクリプトはパネルのほうに貼って、そのパネルをボタンに入れるんだぜ。

    [SerializeField] GameObject m_Kekka = default;

    // Start is called before the first frame update
    private void Start()
    {
        m_Kekka.SetActive(true);
    }
    public void PanelKakusu()
    {
        foreach (Transform child in m_Kekka.transform)
        {
            // 子オブジェクトを一つずつ破棄する
            Destroy(child.gameObject);
        }
        this.gameObject.SetActive(false);
    }

}
