using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    Rigidbody2D rb;
    public float jumpForce = 5f;
    private bool isGrounded;
    private float moveSpeed = 4;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        float moveInput = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);

        if (moveInput > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // 오른쪽
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // 왼쪽
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 2중 점프 방지
            animator.SetTrigger("Jump");
        }

        // 걷기 애니메이션 관리
        if (moveInput != 0 && isGrounded)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        // 착지 애니메이션 상태 확인
        animator.SetBool("Grounded", isGrounded);

        // 점프 애니메이션이 끝난 후 트리거 리셋
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.ResetTrigger("Jump");
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
