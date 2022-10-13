using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject empty;

    Transform[,] grid;

    public int width = 10, height = 30, hearder = 8;
    private void Awake()
    {
        
    }
    private void Start()
    {
        for (int y = 0; y < height-hearder; y++)
        {
            for (int x = 0; x < width; x++)
            {
                GameObject gri=Instantiate(empty, new Vector3(x, y), Quaternion.identity);
                gri.transform.parent = this.transform;
            }
        }
    }
}
