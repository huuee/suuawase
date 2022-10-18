using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    int cou = 0;    //�������̗�
    Board board;
    Spawrn spawrn;
    GameManager gmana;
    [SerializeField]bool canRotate=true;
    private void Awake()
    {
        board = GameObject.FindObjectOfType<Board>();
        spawrn = GameObject.FindObjectOfType<Spawrn>();
        gmana = GameObject.FindObjectOfType<GameManager>();
    }
    public void MoveUp()
    {
        idou(0, 1);
    }
    public void MoveDown()
    {
        idou(0, -1);
    }
    public void MoveRight()
    {
        idou(1, 0);
    }

    public void MoveLeft()
    {
        idou(-1, 0);
    }
    void idou(int x,int y)
    {
        transform.position += new Vector3(x, y);
        transform.position = Rounnd.round(transform.position);
    }

    public void RotateRight()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, 90);
            transform.position = Rounnd.round(transform.position);
        }
    }
    public void RotateLeft()
    {
        if (canRotate)
        {
            transform.Rotate(0, 0, -90);
            transform.position = Rounnd.round(transform.position);
        }
    }
    
    //�u���b�N����������ɏՓ˂���������
    public bool CheckBlock(Block block)
    {
        foreach (Transform item in block.transform)
        {
            if(!Checksoto(item.position))
            {
                return false;
            }
            if(!CheckotherBlock(item.position))
            {
                return false;
            }
        }
        return true;
    }
    //�u���b�N�����Ɖ�����͂ݏo����false
    bool Checksoto(Vector2 pos)
    {
        Vector2 iti = Rounnd.round(pos);
        return (iti.x >= 0 && iti.x < board.width && iti.y >= 0);
    }
    //�u���b�N���ق��̃u���b�N�ƂԂ�������false
    bool CheckotherBlock(Vector2 pos)
    {
        Vector2 iti = Rounnd.round(pos);
        return (!board.grid[(int)iti.x,(int)iti.y]);
    }
    //�u���b�N�̈ʒu���Z�[�u
    public void saveblock(Block block)
    {
        foreach (Transform item in block.transform)
        {
            Vector2 pos=Rounnd.round(item.position);
            board.grid[(int)pos.x, (int)pos.y] = true;
        }
    }

    //��񂻂�������m�F���č폜���˗�
    public void Checkretu()
    {
        bool flag = true;  //true�ɂȂ�ƂP�񂻂���Ă�����
        for (int y = 0; y < board.height-board.hearder; y++)
        {
            for (int x = 0; x < board.width; x++)
            {
                if (!board.grid[x, y]) flag = false; //������Ɍ��Ԃ��Ȃ�������flag��false�ɂ���
            }
            if (flag)
            {
                DestroyBlock(y);
                rakka(y);
                y--;
            }
            flag = true;
        }
        if (cou == 1) gmana.score += 100;
        if (cou == 2) gmana.score += 300;
        if (cou == 3) gmana.score += 500;
        if (cou >= 4) gmana.score += 800;
        if (cou >= 1 && cou <= 3) gmana.se(gmana.ontwothreeline);
        else if (cou == 4) gmana.se(gmana.fourline);
        cou = 0;
    }
    //��������������
    void DestroyBlock(int y)
    {
        GameObject block;
        GameObject chiblock;
        cou++;
        for (int x = 0; x < board.width; x++)
        {
            if (board.grid[x, y]) board.grid[x, y] = false; //�f�[�^�̕��̃u���b�N������

            for (int i = 0; i < spawrn.memblock.Count; i++)
            {
                block=spawrn.memblock[i];
                for (int j = 0; j < block.transform.childCount; j++)  //���ۂɌ�����u���b�N������
                {
                    chiblock = block.transform.GetChild(j).gameObject;
                    if (chiblock.transform.position == new Vector3(x, y)) Destroy(chiblock);
                }
            }
        }
    }
    void rakka(int yy)    //�u���b�N����������ɏ������񕪂��������邠��
    {
        GameObject block;
        GameObject chiblock;
        Vector3 down = new Vector3(0, -1, 0);
        Vector3 up = new Vector3(0, 1, 0);
        for (int y = yy; y < board.height - board.hearder; y++)
        {
            for (int x = 0; x < board.width; x++)
            {
                board.grid[x, y] = board.grid[x, y + 1];     //�f�[�^�̕��̃u���b�N���ړ�

            }
        }
        for (int i = 0; i < spawrn.memblock.Count; i++)
        {
            block = spawrn.memblock[i];
            for (int j = 0; j < block.transform.childCount; j++)
            {
                chiblock = block.transform.GetChild(j).gameObject;
                if (chiblock.transform.position.y > yy) chiblock.transform.position += down;
                if (block.GetComponent<Block>() == gmana.holdblock) //�z�[���h���Ă�u���b�N���ΏۂɂȂ�̂�
                {                                                   //��������������ɂ����鏈��������
                    chiblock.transform.position += up;
                    break;
                }
            }
        }

    }
}
