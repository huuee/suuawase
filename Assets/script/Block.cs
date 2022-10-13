using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    public void MoveDown()
    {
        idou(0, -1);
    }
    void idou(int x,int y)
    {
        transform.Translate(x, y, 0);
    }
}
