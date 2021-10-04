using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedDropDestroy : MonoBehaviour
{
    public static bool fireAttackFlag = false;
    public static bool fireMagicFlag = false;
    [SerializeField] AudioSource m_aud = default;
    AudioClip m_destroySE; //ドロップ消滅音

    void Start()
    {
        fireAttackFlag = false;
        fireMagicFlag = false;
        m_destroySE = m_aud.clip;

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            if (Enemy.m_currentEHp >= 0)
            {
                if (collision.gameObject.tag == "SRed")
                {
                    AudioSource.PlayClipAtPoint(m_destroySE, transform.position, 0f);
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    fireAttackFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }

                if (collision.gameObject.tag == "CRed")
                {
                    AudioSource.PlayClipAtPoint(m_destroySE, transform.position);
                    Destroy(collision.gameObject);
                    Destroy(this.gameObject);
                    this.gameObject.SetActive(false);
                    DropsGenerater.dropsDestroyFlag = false;
                    fireMagicFlag = true;

                    GameManager.SetTurn(GameManager.Turn.PlayerTurn);
                }
            }
        }
    }
}
