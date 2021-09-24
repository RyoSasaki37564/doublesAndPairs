using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AbyssLethal : EnergyMatrix
{
    float m_DoubleDamageIce1;
    float m_DoubleDamageIce2;

    // Start is called before the first frame update
    void Start()
    {
        m_DoubleDamageIce1 = PlayerPrefs.GetInt("BlueS");
        m_DoubleDamageIce2 = PlayerPrefs.GetFloat("BlueC");
        Generate();
    }

    void Update()
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (BlueDropDestroy.iceAttackFlag == true)
            {
                Enemy.m_currentEHp -= (int)m_DoubleDamageIce1;
            }
            if (BlueDropDestroy.iceMagicFlag == true)
            {
                Enemy.m_currentEHp -= (int)m_DoubleDamageIce2;
            }
        }
        else
        {
            Destroy(this.gameObject);
        }
    }

    public override void Generate()
    {
        base.Generate();
        StartCoroutine(AbyssGene());
    }

    IEnumerator AbyssGene()
    {
        yield return new WaitForSeconds(1.0f);
        Generate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Fish")
        {
            Destroy(collision.gameObject);
        }
    }
}
