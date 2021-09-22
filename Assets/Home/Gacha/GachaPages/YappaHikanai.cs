using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YappaHikanai : MonoBehaviour
{
    [SerializeField] GameObject m_kakuninPanel = default; //引くか引かぬか最後の決断

    public void Yamemasu()
    {
        m_kakuninPanel.SetActive(false);
    }
}
