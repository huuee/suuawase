using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonmanager : MonoBehaviour
{
    public int mark = 0;
    public void plus ()
    {
        mark = 0;
    }
    public void minus()
    {
        mark = 1;
    }
    public void kakeru()
    {
        mark = 2;
    }
    public void waru()
    {
        mark = 3;
    }

}
