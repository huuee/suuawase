using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class kabecontroller : MonoBehaviour
{
    public int Point;
    public int Target;
    public int suu;
    int mark;
    GameObject child;
    tamacontroller tama;
    buttonmanager button;
    void Start()
    {
        Point = Random.Range(0, 30);
        Target = Random.Range(100, 150);
        child = transform.GetChild(0).gameObject;
        tama=GameObject.FindObjectOfType<tamacontroller>();
        button=GameObject.FindObjectOfType<buttonmanager>();
    }
    private void OnCollisionEnter2D(Collision2D other)
    {
        suu = tama.suu;
        mark = button.mark;
        if(Point!=Target)
        {
            switch (mark)
            {
                case 0: Point += suu; break; 
                case 1: Point -= suu; break;
                case 2: Point *= suu; break;
                case 3: Point /= suu; break;
            }
            if(Point>500)Point = 500;
        }
    }
}
