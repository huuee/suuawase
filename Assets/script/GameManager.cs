using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public Block activeblock;
    Spawrn spawrn;

    void Start()
    {
        spawrn = GameObject.FindObjectOfType<Spawrn>();
        spawrn.callspawrn();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
