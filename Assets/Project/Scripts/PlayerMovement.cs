using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    private PhotonView view;
    [SerializeField] private float speed;
    [SerializeField] private float jumpForce;
    [SerializeField] private Vector2 dir;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform groundPos;
    [SerializeField] private float checkRadius;
    private bool isRunning;
    private bool facingLeft;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
        anim = GetComponent<Animator>();
    }

    private void Update()
    {
        if (view.IsMine)
        {
            PlayerInputs();
            Animations();

            if (dir.x > 0 && !facingLeft || dir.x < 0 && facingLeft) Flip();
        }
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
        {
            PlayerMove();
        }
    }

    private void PlayerInputs()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        dir = new Vector2(_x, 0);

        if (dir.x != 0)
            isRunning = true;
        else
            isRunning = false;

        if (Input.GetButtonDown("Jump")) PlayerJump();
    }

    private void PlayerMove()
    {
        rb.velocity = new Vector2(dir.x * speed, rb.velocity.y);
    }

    private void PlayerJump()
    {
        if (!OnGround()) return;

        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
    }

    private bool OnGround()
    {
        return Physics2D.OverlapCircle(
            groundPos.position, 
            checkRadius, 
            groundLayer);
    }

    private void Flip()
    {
        facingLeft = !facingLeft;
        transform.Rotate(Vector3.up * 180f);
    }

    private void Animations()
    {
        anim.SetBool("IsRunning", isRunning);
    }
}