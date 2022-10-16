using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Rounnd
{
    public static Vector2 round(Vector2 pos)
    {
        return new Vector2(Mathf.Round(pos.x), Mathf.Round(pos.y));
    }
}
