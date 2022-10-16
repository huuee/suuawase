using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Board : MonoBehaviour
{
    [SerializeField]
    GameObject empty;

    public bool[,] grid;
    SpriteRenderer spren;
    public int width = 10, height = 30, hearder = 8;
    private void Awake()
    {
        grid = new bool[width, height];
    }
    private void Start()
    {
        for (int y = 0; y < height-hearder; y++)
        {
            for (int x = 0; x < width; x++)
            {
                //グリッド(マス目)の生成
                GameObject gri=Instantiate(empty, new Vector3(x, y), Quaternion.identity);
                spren = gri.GetComponent<SpriteRenderer>();
                //spren.sortingOrder 
                gri.transform.parent = this.transform;
                //マス目のデータの初期化
                grid[x, y] = false;
            }
        }
    }
}
