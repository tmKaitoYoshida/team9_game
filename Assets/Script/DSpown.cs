using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DSpown : MonoBehaviour
{

    // Start is called before the first frame update
    void Start()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {

            // �Ԃ�������f�X
            PlayerControl.Death();


        }
    }

    // Update is called once per frame
    void Update()
    {

    }
}
