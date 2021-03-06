using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMoveContloller : MonoBehaviour
{
    Rigidbody2D m_fishBody;
    float m_speed = -0.002f;
    float m_ranges = 0.04f;
    float rondom;

    // Start is called before the first frame update
    void Start()
    {
        m_fishBody = this.gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        rondom = Random.Range(-1*m_ranges/2, m_ranges/2);
        m_fishBody.AddForce(new Vector2(m_speed, rondom), ForceMode2D.Force);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "OutLine")
        {
            rondom = Random.Range(-1*m_ranges, m_ranges);
            m_speed *= -1;
            this.gameObject.transform.localScale = new Vector3(this.gameObject.transform.localScale.x * -1, 
                this.gameObject.transform.localScale.y,
                this.gameObject.transform.localScale.z);
        }

    }
}
