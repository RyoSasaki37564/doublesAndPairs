﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoToDustBox : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.parent = GameObject.Find("DustBox").transform;
        //GoHome.csと連携しとるよん
    }

}
