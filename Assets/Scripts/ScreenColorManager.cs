using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenColorManager : MonoBehaviour
{
    [SerializeField]SpriteRenderer m_spR;

    // Start is called before the first frame update
    private void Start()
    {
        m_spR.color = new Color32(0, 0, 0, 0);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (GameManager.turn == GameManager.Turn.EnemyTurn)
        {
            m_spR.color = new Color32(255, 0, 0, 100); //敵の攻撃で赤くなる
            StartCoroutine(ScreenReset());
        }
    }

    IEnumerator ScreenReset()
    {
        yield return new WaitForSeconds(1.2f);
        m_spR.color = new Color32(0, 0, 0, 0);
    }
}
