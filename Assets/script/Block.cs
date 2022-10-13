using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Block : MonoBehaviour
{
    Board board;
    private void Start()
    {
        board = GameObject.FindObjectOfType<Board>();
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
        transform.Translate(x, y, 0);
    }

    public void RotateRight()
    {
        transform.Rotate(0, 0, 90);
    }
    public void RotateLeft()
    {
        transform.Rotate(0, 0, -90);
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
        return (pos.x >= 0 && pos.x < board.width && pos.y >= 0);
    }
    //�u���b�N���ق��̃u���b�N�ƂԂ�������false
    bool CheckotherBlock(Vector2 pos)
    {
        return (!board.grid[(int)pos.x,(int)pos.y]);
    }
    //�u���b�N�̈ʒu���Z�[�u
    public void saveblock(Block block)
    {
        foreach (Transform item in block.transform)
        {
            board.grid[(int)item.position.x, (int)item.position.y] = true; 
        }
    }
}
