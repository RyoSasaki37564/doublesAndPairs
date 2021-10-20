using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;
using UnityEngine.UI;

public class CharaIconManager : MonoBehaviour
{
    [SerializeField] GameObject[] m_usingChara = new GameObject[CharaID.m_usingCharaID.Count]; //実装されているすべてのキャラ
    [SerializeField] GameObject[] party = new GameObject[CharaID.m_usingCharaID.Count]; //編成したキャラ
    [SerializeField] LayoutGroup m_deck = default; //戦闘画面におけるキャラの配置
    int id; //ID番号を数値化するための容器

    //戦闘開始時、パーティに編成されたキャラのIDを受け取ってメンバーを生成する

    // Start is called before the first frame update
    void Start()
    {
        for (var i = 0; i < party.Length; i++)
        {
            id = CharaID.m_usingCharaID[i];

            party[i] = Instantiate(m_usingChara[id]);

            party[i].transform.SetParent(m_deck.transform);

            party[i].transform.localScale = new Vector3(1, 1, 0);

            party[i].SetActive(true);
        }

    }

}
