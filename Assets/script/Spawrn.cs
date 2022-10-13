using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawrn : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    Board board;
    GameManager gmana;
    private void Awake()
    {
        board = GameObject.FindObjectOfType<Board>();
        gmana = GameObject.FindObjectOfType<GameManager>();
    }
    //ブロックを生成する関数を呼ぶ関数
    public void callspawrn()
    {
        int rand = Random.Range(0, blocks.Length);
        Spawrnblock(rand);
    }

    //ブロックを生成する
    void Spawrnblock(int i)
    {
        float pos_x = board.width / 2 - 1;
        float pos_y = board.height - board.hearder;
        GameObject block=Instantiate(blocks[i], new Vector2(pos_x, pos_y), Quaternion.identity);
        gmana.activeblock = block.GetComponent<Block>();
    }
}
