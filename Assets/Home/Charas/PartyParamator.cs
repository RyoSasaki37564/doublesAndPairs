using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PartyParamator : MonoBehaviour
{
    int m_hp = PlayerPrefs.GetInt("PlayerHp", 0); //パーティ体力

    int m_fireButuri = PlayerPrefs.GetInt("RedS", 0); //パーティ火属性物理

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
