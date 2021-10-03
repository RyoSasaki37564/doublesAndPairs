using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrystalSecondFazer : EnergyMatrix
{
    int m_turnCount = 0;

    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    public override void Generate()
    {
        //エナジーマトリックスの再帰
        base.Generate();
        StartCoroutine(AbyssGene());
        if (GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_turnCount++;
            if (m_turnCount == 2)
            {
                Destroy(this.gameObject);
            }
        }
    }
    IEnumerator AbyssGene()
    {
        //エナジーマトリックスの再帰
        yield return new WaitForSeconds(2.0f);
        Generate();
    }
}
