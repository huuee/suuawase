using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Block activeblock;
    Spawrn spawrn;
    float timer = 0;

    void Start()
    {
        spawrn = GameObject.FindObjectOfType<Spawrn>();
        spawrn.callspawrn();
    }

    void Update()
    {
        timer += Time.deltaTime;
        if(timer>0.5f)
        {
            activeblock.MoveDown();
            timer = 0;
        }
    }
}
