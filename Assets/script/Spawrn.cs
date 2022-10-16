using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawrn : MonoBehaviour
{
    [SerializeField] GameObject[] blocks;
    Board board;
    GameManager gmana;
    public List<GameObject> memblock = new List<GameObject>();
    private void Awake()
    {
        board = GameObject.FindObjectOfType<Board>();
        gmana = GameObject.FindObjectOfType<GameManager>();

        int rand = Random.Range(0, blocks.Length);
        GameObject block = Instantiate(blocks[rand]);
        gmana.nextblock = block.GetComponent<Block>();
        block.transform.parent = gameObject.transform;
    }
    //�u���b�N�𐶐�����֐����ĂԊ֐�
    public void callspawrn()
    {
        int rand = Random.Range(0, blocks.Length);
        Spawrnblock(rand);
    }

    //�u���b�N�𐶐�����
    void Spawrnblock(int i)
    {
        //i = 0;
        float pos_x = board.width / 2 - 1;
        float pos_y = board.height - board.hearder;
        gmana.activeblock = gmana.nextblock;//block.GetComponent<Block>();
        gmana.activeblock.transform.position = new Vector2(pos_x, pos_y);
        memblock.Add(gmana.activeblock.gameObject);

        GameObject block = Instantiate(blocks[i], new Vector2(13f, 17.5f), Quaternion.identity);
        gmana.nextblock=block.GetComponent<Block>();
        block.transform.parent = gameObject.transform;
    }
    public void holdblock(Block block)
    {
        if(!gmana.holdblock)    //�����z�[���h���ĂȂ�������
        {
            gmana.holdblock = block;
            callspawrn();
        }
        else
        {
            float pos_x = board.width / 2 - 1;
            float pos_y = board.height - board.hearder;
            Quaternion rot = new Quaternion(0, 0, 0, 0);
            Block w = gmana.activeblock;
            gmana.activeblock = gmana.holdblock;
            gmana.holdblock = w;
            gmana.activeblock.transform.position = new Vector2(pos_x, pos_y);
            gmana.holdblock.transform.localRotation = Quaternion.identity;
        }
       �@gmana.holdblock.transform.position = new Vector2(-4f, 17.5f);
    }
}
