using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Photon.Pun;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D rb;
    private PhotonView view;
    [SerializeField] private float speed;
    [SerializeField] private Vector2 dir;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        view = GetComponent<PhotonView>();
    }

    private void Update()
    {
        if (view.IsMine)
            PlayerInputs();
    }

    private void FixedUpdate()
    {
        if (view.IsMine)
            PlayerMove();
    }

    private void PlayerInputs()
    {
        float _x = Input.GetAxisRaw("Horizontal");
        dir = new Vector2(_x, 0);
    }

    private void PlayerMove()
    {
        rb.velocity = dir * speed;
    }
}