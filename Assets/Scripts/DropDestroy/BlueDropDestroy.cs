using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueDropDestroy : MonoBehaviour
{
    public static bool iceAttackFlag = false;
    public static bool iceMagicFlag = false;
    [SerializeField] AudioSource m_aud = default;
    AudioClip m_destroySE; //ドロップ消滅音

    void Start()
    {
        iceAttackFlag = false;
        iceMagicFlag = false;
        m_destroySE = m_aud.clip;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (Enemy.m_currentEHp >= 0)
            {
                if (collision.gameObject.tag == "SBlue")
                {
                    AudioSource.PlayClipAtPoint(m_destroySE, transform.position, 0f);
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    iceAttackFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }

                if (collision.gameObject.tag == "CBlue")
                {
                    AudioSource.PlayClipAtPoint(m_destroySE, transform.position);
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    iceMagicFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }
            }

        }
    }
}
