using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CharaIconManager : MonoBehaviour
{
    [SerializeField] const int c_usingCharaCount = 5;
    [SerializeField] GameObject m_usingChara = default;
    [SerializeField] GameObject[] party = new GameObject[c_usingCharaCount];
    [SerializeField] LayoutGroup m_deck = default;


    // Start is called before the first frame update
    void Start()
    {
        for(var i = 0; i < c_usingCharaCount; i++)
        {
            var x = Instantiate(m_usingChara);
            party[i] = x;
            party[i].SetActive(true);
            party[i].transform.SetParent(m_deck.transform);
            party[i].transform.localScale = new Vector3(1, 1, 0);
        }
    }

}
