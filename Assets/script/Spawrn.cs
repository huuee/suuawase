using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawrn : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    Board board;
    GameManager gmana;
    private void Start()
    {
        board = GameObject.FindObjectOfType<Board>();
        gmana = GameObject.FindObjectOfType<GameManager>();
    }
    //�u���b�N�𐶐�����֐����ĂԊ֐�
    public void callspawrn()
    {
        int rand = Random.Range(0, blocks.Length + 1);
        Spawrnblock(rand);
    }

    //�u���b�N�𐶐�����
    void Spawrnblock(int i)
    {
        float pos_x = board.width / 2;
        float pos_y = board.height - board.hearder;
        Instantiate(blocks[i], new Vector2(pos_x, pos_y), Quaternion.identity);
    }
}