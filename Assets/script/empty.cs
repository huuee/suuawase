using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class empty : MonoBehaviour
{
    [SerializeField] Sprite sprite;
    [SerializeField] Sprite sprite2;
    SpriteRenderer spren;
    Board board;
    Vector2 pos;
    private void Start()
    {
        board = GameObject.FindObjectOfType<Board>();
        spren = GetComponent<SpriteRenderer>();
        pos = transform.position;
    }
    void Update()
    {
        //if (board.grid[(int)pos.x, (int)pos.y]) spren.sprite = sprite;
        //else spren.sprite = sprite2;
    }
}
