using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestLethal : MonoBehaviour
{
    public void Lethal()
    {
        Enemy.m_currentEHp -= Player.thePMAXHP/2;
        Destroy(gameObject);
    }
}
