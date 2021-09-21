using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharaBox : MonoBehaviour
{
    [SerializeField] GameObject m_CHARAICON = default;

    [SerializeField] LayoutGroup m_GL = default;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < 50; i++)
        {
            var x = Instantiate(m_CHARAICON);
            x.transform.SetParent(m_GL.transform);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
