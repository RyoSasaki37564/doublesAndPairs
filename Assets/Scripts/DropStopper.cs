using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropStopper : MonoBehaviour
{
    private const float c_maxX = 2.3f;
    private const float c_minX = -2.3F;
    private const float c_maxY = 0f;
    private const float c_minY = -4.8F;

    // Update is called once per frame
    void Update()
    {
        MoveDrop();
    }

    void MoveDrop()
    {
        //ドロップが移動制限軸に触れたときその座標をそれ以上進行しないようにする
        if (GameManager.turn == GameManager.Turn.InputTurn || GameManager.turn == GameManager.Turn.PlayerTurn)
        {
            Vector3 dropPos = transform.position;

            if (c_maxX < dropPos.x)
            {
                dropPos.x = c_maxX;
            }
            if (c_minX > dropPos.x)
            {
                dropPos.x = c_minX;
            }

            if (c_maxY < dropPos.y)
            {
                dropPos.y = c_maxY;
            }
            if (c_minY > dropPos.y)
            {
                dropPos.y = c_minY;
            }

            transform.position = dropPos;
        }
    }
}

