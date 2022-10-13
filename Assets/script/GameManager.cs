using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Block activeblock;
    Spawrn spawrn;
    float timer = 0;

    float nextDowntimer;
    float nextLeftRighttimer;
    float nextRotateimer;
    [SerializeField]float nextDownInterval;
    [SerializeField]float nextLeftRightInterval;
    [SerializeField]float nextRotateInterval;
    void Start()
    {
        spawrn = GameObject.FindObjectOfType<Spawrn>();
        spawrn.callspawrn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>0.1f)
        {
            timer = 0;
            activeblock.MoveDown();
            if(!activeblock.CheckBlock(activeblock))
            {
                activeblock.MoveUp();
                activeblock.saveblock(activeblock);
                spawrn.callspawrn();
            }
        }
        Player();
    }
    void Player()
    {
        if((Input.GetKey(KeyCode.D)&&nextLeftRighttimer<Time.time)|| Input.GetKeyDown(KeyCode.D))
        {
            nextLeftRighttimer = Time.time + nextLeftRightInterval;
            activeblock.MoveRight();
            if (!activeblock.CheckBlock(activeblock))
            {
                activeblock.MoveLeft();
            }
        }
        if ((Input.GetKey(KeyCode.A) && nextLeftRighttimer < Time.time) || Input.GetKeyDown(KeyCode.A))
        {
            nextLeftRighttimer = Time.time + nextLeftRightInterval;
            activeblock.MoveLeft();
            if (!activeblock.CheckBlock(activeblock))
            {
                activeblock.MoveRight();
            }
        }
    }
}
