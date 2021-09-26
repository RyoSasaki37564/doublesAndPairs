using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGroundManager : MonoBehaviour
{
    [SerializeField] List<Sprite> m_backGroundSprite = new List<Sprite>(); //背景画像リスト

    SpriteRenderer m_Sprite = default; //背景画像

    public static int m_QuestMasterID; //クエスト番号

    FadeIO m_f = new FadeIO();

    // Start is called before the first frame update
    void Start()
    {
        //クエストIDに応じた背景をセット
        m_QuestMasterID = PlayerPrefs.GetInt("Quest");
        m_Sprite = GetComponent<SpriteRenderer>();
        m_Sprite.sprite = m_backGroundSprite[m_QuestMasterID];
    }
    private void Update()
    {
        if(FadeIO.m_isNight == true)
        {
            m_Sprite.sprite = m_backGroundSprite[3];
        }
        if(GameManager.turn == GameManager.Turn.CleanUpTurn)
        {
            m_Sprite.sprite = m_backGroundSprite[m_QuestMasterID];
        }
    }
}
