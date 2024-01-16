using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour
{
    Rigidbody2D rigid;
    public float speed = 5.0f;

    private void Start()
    {
        rigid = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        MovePlayer();
    }

    private void MovePlayer()
    {
        Vector2 moveVec = new Vector2(Input.GetAxis("Horizontal"),
                                      Input.GetAxis("Vertical"));

        rigid.velocity = moveVec * speed;
    }
}
