using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RicoreLethalFazer : EnergyMatrix
{
    // Start is called before the first frame update
    void Start()
    {
        Generate();
    }

    // Update is called once per frame
    void Update()
    {
        //ターンの終わり、退却時に効果終了
        if (GameManager.turn == GameManager.Turn.CleanUpTurn || GameManager.turn == GameManager.Turn.GameEnd ||
            GameManager.turn == GameManager.Turn.GameOut || GiveUp.m_akirame == true)
        {
            GameManager.m_timeLange = GameManager.TimeLange.Normal;
            RicoreFazer.m_RicoreCanUse = false;
            Destroy(this.gameObject);
        }
    }

    public override void Generate()
    {
        //エナジーマトリックスの再帰
        base.Generate();
        StartCoroutine(AccelarationGene());
    }
    IEnumerator AccelarationGene()
    {
        //エナジーマトリックスの再帰
        yield return new WaitForSeconds(0.3f);
        Generate();
    }
}
