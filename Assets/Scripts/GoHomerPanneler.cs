using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoHomerPanneler : MonoBehaviour
{
    [SerializeField] GameObject m_obj = default; //ホームに還りますか？

    // Start is called before the first frame update
    void Start()
    {
        m_obj.SetActive(false);
    }

    public void OhYeah()
    {
        m_obj.SetActive(true);
    }
}
