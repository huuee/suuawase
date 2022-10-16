using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Block activeblock;
    public Block nextblock;
    public Block holdblock;
    public bool canhold = true;
    bool canSkey = true;    //ÇrÉLÅ[ÇóLå¯Ç…Ç∑ÇÈÇ©Ç«Ç§Ç©
    Spawrn spawrn;
    Board board;
    float timer = 0;

    public float nextDowntimer;
    float nextLeftRighttimer;
    [SerializeField]float nextDownInterval;
    [SerializeField]float nextLeftRightInterval;
    [SerializeField] GameObject Panel;
    void Start()
    {
        spawrn = GameObject.FindObjectOfType<Spawrn>();
        board = GameObject.FindObjectOfType<Board>();
        spawrn.callspawrn();
        if(Panel.activeInHierarchy)Panel.SetActive(false);
    }

    void Update()
    {
        Player();
        endgame();
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
        if (Input.GetKey(KeyCode.S)&&canSkey) nextDownInterval = 0.01f;
        else nextDownInterval = 0.2f;
        if (Input.GetKeyUp(KeyCode.S)) canSkey = true;

        if (nextDowntimer < Time.time)
        {
            nextDowntimer = Time.time + nextDownInterval;
            activeblock.MoveDown();
            if (!activeblock.CheckBlock(activeblock))
            {
                if (activeblock.transform.position.y + 1 >= board.height - board.hearder)
                {
                    nextDowntimer = 99999;
                    Panel.SetActive(true);
                }

                activeblock.MoveUp();
                activeblock.saveblock(activeblock);
                activeblock.Checkretu();
                spawrn.callspawrn();
                canhold = true;
                canSkey = false;
            }
        }
        if(Input.GetKeyDown(KeyCode.W)) //èuéûÇ…â∫Ç…ç~ÇËÇÈ
        {
            do
            {
                activeblock.MoveDown();
            } while (activeblock.CheckBlock(activeblock));
            activeblock.MoveUp();
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            activeblock.RotateLeft();
            if (!activeblock.CheckBlock(activeblock))
            {
                activeblock.RotateRight();
            }
        }
        if(Input.GetKeyDown(KeyCode.C)&&canhold)
        {
            spawrn.holdblock(activeblock);
            canhold = false;
        }
    }
    void endgame()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            #if UNITY_EDITOR
                        UnityEditor.EditorApplication.isPlaying = false;
            #elif UNITY_STANDALONE
                        UnityEngine.Application.Quit();
            #endif
        }
    }
    public void RightButton()
    {
        nextLeftRighttimer = Time.time + nextLeftRightInterval;
        activeblock.MoveRight();
        if (!activeblock.CheckBlock(activeblock))
        {
            activeblock.MoveLeft();
        }
    }
    public void LeftButton()
    {
        nextLeftRighttimer = Time.time + nextLeftRightInterval;
        activeblock.MoveLeft();
        if (!activeblock.CheckBlock(activeblock))
        {
            activeblock.MoveRight();
        }
    }
    public void RotateButton()
    {
        activeblock.RotateLeft();
        if (!activeblock.CheckBlock(activeblock))
        {
            activeblock.RotateRight();
        }
    }
    public void HoldButton()
    {
        if (canhold)
        {
            spawrn.holdblock(activeblock);
            canhold = false;
        }
    }
    public void DownButton()
    {
        do
        {
            activeblock.MoveDown();
        } while (activeblock.CheckBlock(activeblock));
        activeblock.MoveUp();
    }
    public void Retry()
    {
        SceneManager.LoadScene(0);
    }
}
