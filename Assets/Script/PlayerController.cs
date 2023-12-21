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
        // �W�����v
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            Jump();
        }

        // ���E�ړ�
        float horizontalInput = Input.GetAxis("Horizontal");
        Move(horizontalInput);

        // ���Ⴊ��
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
        // �n�ʂɐڐG���Ă��邩�ǂ����̔���
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
        // ���Ⴊ�ޏ�����ǉ��i��: Collider�̃T�C�Y�ύX�Ȃǁj
    }

    void StandUp()
    {
        isCrouching = false;
        // �����オ�鏈����ǉ��i��: Collider�̃T�C�Y�߂��Ȃǁj
    }
}


