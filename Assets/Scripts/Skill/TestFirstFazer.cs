using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestFirstFazer : MonoBehaviour
{
    [SerializeField] int m_firstFazerAttack = 1000;

    public void First()
    {
            Enemy.m_currentEHp -= m_firstFazerAttack;
            Destroy(gameObject);
    }
}
