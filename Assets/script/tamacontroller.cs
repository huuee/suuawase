using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tamacontroller : MonoBehaviour
{
    public int suu = 7;
    Rigidbody2D rigid;
    Vector2 velo;
    Vector2 mem;
    bool flag=false;
    void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
        rigid.velocity = new Vector2(1.2f, 2.5f);
    }
    void Update()
    {
        float mag = Mathf.Abs(rigid.velocity.magnitude);
        velo.x=rigid.velocity.x;
        velo.y=rigid.velocity.y;

        if (mag > 5 && !flag)
        {
            mem = velo;
            if (mem.x < 0) mem.x = -mem.x;
            if (mem.y < 0) mem.y = -mem.y;
            flag = true;
        }
        if (flag) 
        {
            if(velo.x>0)velo.x = mem.x;
            else velo.x = -mem.x;
            if (velo.y > 0)
            {
                velo.y = mem.y;
            }
            else if (velo.y < 0) 
            {
                velo.y = -mem.y;
            }
        }
        rigid.velocity = velo;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        GetComponent<AudioSource>().Play();
    }
}
