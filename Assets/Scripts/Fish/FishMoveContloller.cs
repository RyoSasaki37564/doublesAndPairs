using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoveContloller : MonoBehaviour
{
    Rigidbody2D m_fishBody;
    SpriteRenderer m_fishSpr;
    float m_speed = -1f;
    float rondom;

    // Start is called before the first frame update
    void Start()
    {
        m_fishBody = this.gameObject.GetComponent<Rigidbody2D>();
        m_fishSpr = this.gameObject.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        m_fishBody.AddForce(new Vector2(m_speed, rondom), ForceMode2D.Force);
        rondom = Random.Range(-2, 3);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OutLine")
        {
            m_speed *= -1;
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, this.gameObject.transform.localScale.y,
                this.gameObject.transform.localScale.z);
        }

        if (collision.gameObject.tag == "Respawn")
        {
            rondom = Random.Range(-2, 3);
        }
    }
}
