using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ClearGift : MonoBehaviour
{
    [SerializeField] GameObject m_winningGiftPannel = default; //報酬パネル
    [SerializeField] List<Sprite> m_dropCharaSprite = new List<Sprite>(); //泥キャラ画像リスト
    [SerializeField] Image m_dropImage = default;　//ドロップキャラ画像
    int m_queID; //クエストID容器

    // Start is called before the first frame update
    void Start()
    {
        if(Player.m_currentPHp > 0)
        {
            m_winningGiftPannel.SetActive(true);
            m_queID = PlayerPrefs.GetInt("Quest");
            m_dropImage.sprite = m_dropCharaSprite[m_queID];
        }
        else
        {
            m_winningGiftPannel.SetActive(false);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
