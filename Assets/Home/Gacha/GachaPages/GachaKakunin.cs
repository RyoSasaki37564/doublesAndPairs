using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GachaKakunin : MonoBehaviour
{
    [SerializeField] GameObject m_kakuninPanel = default; //本当に引くかどうかの確認

    // Start is called before the first frame update
    void Start()
    {
        //m_kakuninPanel.SetActive(false);
    }

    public void Hikukamo()
    {
        m_kakuninPanel.SetActive(true);
    }
}
