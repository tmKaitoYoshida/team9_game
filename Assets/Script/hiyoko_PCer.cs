using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hiyoko_PCer : MonoBehaviour
{
    public float speed = 8f;
    public float power = 1000f;
    public float moveableRange = 5.5f;
    public float rotateSpeed = 400f;
    public bool isGrounded;
    private bool isCrouching = false;
    public GameObject mazzle;
    public GameObject ball;
    public Transform spawnPoint;
    public float shootTimeLeft = 0.5f;
    private float timeLeft;

    private void Start()
    {
        //発射間隔の時間を初期値に設定
        timeLeft = shootTimeLeft; 
    }

    void Update() {
        //発射間隔の残り時間を更新
        timeLeft = timeLeft - Time.deltaTime;

        // Aキーが押されていたら
        if (Input.GetKey(KeyCode.A))
        {
            this.transform.Translate((-1)*speed * Time.deltaTime, 0, 0);
            this.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange), transform.position.y);
        }

        // Dキーが押されていたら
        if (Input.GetKey(KeyCode.D))
        {
            this.transform.Translate(speed * Time.deltaTime, 0, 0);
            this.transform.position = new Vector2(Mathf.Clamp(transform.position.x, -moveableRange, moveableRange), transform.position.y);
        }

        // Wキーが押されていたら
        if (Input.GetKeyDown(KeyCode.W) && isGrounded)
        {
            
        }

        // Sキーが押されていたら
        if (Input.GetKey(KeyCode.S))
        {
            mazzle.transform.Rotate(0, 0, (-1)*rotateSpeed * Time.deltaTime);
        }


        // スペースキーが押されていたら
        if (Input.GetKey(KeyCode.Space))
        {
            //発射間隔の残り時間が0以下なら，Shootして発射間隔を戻す．
            if(timeLeft <= 0.0)
            {
                Shoot();
                timeLeft = shootTimeLeft;
            }
           
        }

        //今、マウスの左ボタンが押された
        if (Input.GetMouseButtonDown(0))
        {
           print("いま左ボタンが押された。(x,y)="+"("+Input.mousePosition.x+", "+ Input.mousePosition.y+")");
        }

        //今、マウスの左ボタンが離された
        if (Input.GetMouseButtonUp(0))
        {
            print("いま左ボタンが離された。(x,y)=" + "(" + Input.mousePosition.x + ", " + Input.mousePosition.y + ")");
        }

    }

    void Shoot()
    {
        GameObject newBullet = Instantiate(ball, spawnPoint.position, Quaternion.identity) as GameObject;
        newBullet.GetComponent<Rigidbody2D>().AddForce(mazzle.transform.right * power);
    }

}
