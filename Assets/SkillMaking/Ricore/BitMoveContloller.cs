using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BitMoveContloller : MonoBehaviour
{
    Rigidbody2D m_bitBody;
    float m_speed = -0.5f;
    float rondom;

    // Start is called before the first frame update
    void Start()
    {
        m_bitBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rondom = Random.Range(-5f, 5f);
        m_bitBody.AddForce(new Vector2(m_speed, rondom), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OutLine")
        {
            rondom = Random.Range(-5f, 5f);
            m_speed *= -1;
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1,
                this.gameObject.transform.localScale.y,
                this.gameObject.transform.localScale.z);
        }

    }
}
