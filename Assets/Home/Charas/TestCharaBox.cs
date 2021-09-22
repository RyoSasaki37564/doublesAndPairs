using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TestCharaBox : MonoBehaviour
{
    [SerializeField] List<GameObject> m_CHARAICON = new List<GameObject>();

    [SerializeField] LayoutGroup m_GL = default;

    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < 10; i++)
        {
            int rondom = Random.Range(0, m_CHARAICON.Count);
            var x = Instantiate(m_CHARAICON[rondom]);
            x.transform.SetParent(m_GL.transform);
            x.transform.localScale = m_CHARAICON[rondom].transform.localScale;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
