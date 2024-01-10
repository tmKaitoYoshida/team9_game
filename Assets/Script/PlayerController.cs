using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Windows;

public class PlayerControl : MonoBehaviour
{
    private Rigidbody2D rb2d;
    private float x_val;
    private float speed;
    public float inputSpeed;
    public float jumpingPower;
    private Animator _anim;
    public GroundCheck ground;
    private bool isGround = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();

        _anim = GetComponent<Animator>();
    }
    void Update()
    {
        x_val = UnityEngine.Input.GetAxis("Horizontal");


        _anim.SetBool("Run", x_val != 0);

        //Space�������ꂽ�ꍇ
        if (UnityEngine.Input.GetKeyDown("space") && isGround)
        {
            rb2d.AddForce(Vector2.up * jumpingPower);
        }
    }
    void FixedUpdate()
    {

        isGround = ground.IsGround();

        //�ҋ@
        if (x_val == 0)
        {
            speed = 0;
        }
        //�E�Ɉړ�
        else if (x_val > 0)
        {
            speed = inputSpeed;
            //�E����������
            transform.localScale = new Vector3((float)0.1, (float)0.1, (float)0.1);
        }
        //���Ɉړ�
        else if (x_val < 0)
        {
            speed = inputSpeed * -1;
            //������������
            transform.localScale = new Vector3((float)-0.1, (float)0.1, (float)0.1);
        }

        // �L�����N�^�[���ړ� Vextor2(x���X�s�[�h�Ay���X�s�[�h(���̂܂�))
        rb2d.velocity = new Vector2(speed, rb2d.velocity.y);
    }

    public void Death()
    {
        SceneManager.LoadScene("Gameover");
    }
}