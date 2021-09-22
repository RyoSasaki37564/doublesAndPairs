using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelOff : MonoBehaviour
{
    //自動隠蔽プログラム

    // Start is called before the first frame update
    void Update()
    {
        if(this.gameObject.activeInHierarchy == true)
        {
            StartCoroutine(Hitomazukoredekesu());
        }
    }

    IEnumerator Hitomazukoredekesu()
    {
        yield return new WaitForSeconds(3.0f); 
        foreach (Transform child in this.transform)
        {
            // 子オブジェクトを一つずつ破棄する
            Destroy(child.gameObject);
        }
        this.gameObject.SetActive(false);
    }
}
