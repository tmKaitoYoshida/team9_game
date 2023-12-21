using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 10f;
    public bool isGrounded;
    public LayerMask groundLayer;

    private Rigidbody2D rb;
    private bool isCrouching = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        // ジャンプ
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        // 左右移動
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        // しゃがみ
        if (Input.GetKeyDown(KeyCode.S))
        {
            Crouch();
        }
        else if (Input.GetKeyUp(KeyCode.S))
        {
            StandUp();
        }
    }

    void FixedUpdate()
    {
        // 地面に接触しているかどうかの判定
        isGrounded = Physics2D.OverlapCircle(transform.position, 0.2f, groundLayer);
    }

    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    void Move(float horizontalInput)
    {
        Vector2 movement = new Vector2(horizontalInput * moveSpeed, rb.velocity.y);
        rb.velocity = movement;
    }

    void Crouch()
    {
        isCrouching = true;
        // しゃがむ処理を追加（例: Colliderのサイズ変更など）
    }

    void StandUp()
    {
        isCrouching = false;
        // 立ち上がる処理を追加（例: Colliderのサイズ戻すなど）
    }
}


