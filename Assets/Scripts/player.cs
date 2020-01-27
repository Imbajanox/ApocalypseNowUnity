using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class player : MonoBehaviour
{

    private bool onGround = false;
    public float jumpPush = 8f;
    public float extraGravity = -5f;

    private Animator anim;
    public bool isWalking = false;
    private Rigidbody rigid;
    private void Start()
    {
        rigid = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        var x = Input.GetAxis("Horizontal") * Time.deltaTime * 150.0f;
        var z = Input.GetAxis("Vertical") * Time.deltaTime * 3.0f;
        var xz = x + z * 15;
        anim.SetFloat("forward", Mathf.Abs(xz));

        transform.Rotate(0, x, 0);
        transform.Translate(0, 0, z);

        RaycastHit hitInfo;
        onGround = Physics.Raycast(transform.position + (Vector3.up * 0.1f), Vector3.down, out hitInfo, 0.12f);
        anim.SetBool("grounded", onGround);
        if (Input.GetAxis("Jump") > 0f && onGround == true)
        {
            Vector3 power = rigid.velocity;
            power.y = jumpPush;
            rigid.velocity = power;
        }
        rigid.AddForce(new Vector3(0f, extraGravity, 0f));
    }
}

