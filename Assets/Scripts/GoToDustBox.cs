using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDustBox : MonoBehaviour
{
    [SerializeField] bool m_isNotStartSetting = false; //親を別のオブジェクトにしておきたいときにチェック。アビスリーサルなどがそう

    // Start is called before the first frame update
    void Start()
    {
        if(m_isNotStartSetting == false)
        {
            transform.parent = GameObject.Find("DustBox").transform;
            //GoHome.csと連携しとるよん
        }
    }

    public void Duster()
    {
        transform.parent = GameObject.Find("DustBox").transform;
        //GoHome.csと連携しとるよん
    }

}
