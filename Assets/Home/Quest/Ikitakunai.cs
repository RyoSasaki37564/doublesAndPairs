using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ikitakunai : MonoBehaviour
{
    [SerializeField] GameObject m_panel = default;

    public void Yamemasu()
    {
        m_panel.SetActive(false);
    }
}
