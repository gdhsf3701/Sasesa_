using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    PlayerInput PlayerInput;
    public float jumpForce = 5f;
    private bool isGrounded;
    private float moveSpeed = 4;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        PlayerInput = GetComponent<PlayerInput>();
        animator = GetComponent<Animator>();
    }
    private void Update()
    {

        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 0); // 오른쪽
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 0); // 왼쪽
        }
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 2중점프 방지
        }
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        // 플레이어가 땅에 닿았는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // 플레이어가 땅에서 벗어났는지 확인
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

}
