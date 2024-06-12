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
            transform.localScale = new Vector3(1, 1, 1); // ������
        }
        else if (moveInput < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ����
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            isGrounded = false; // 2�� ���� ����
            animator.SetTrigger("Jump");
        }

        // �ȱ� �ִϸ��̼� ����
        if (moveInput != 0 && isGrounded)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        // ���� �ִϸ��̼� ���� Ȯ��
        animator.SetBool("Grounded", isGrounded);

        // ���� �ִϸ��̼��� ���� �� Ʈ���� ����
        if (animator.GetCurrentAnimatorStateInfo(0).IsTag("Jump") && animator.GetCurrentAnimatorStateInfo(0).normalizedTime >= 1.0f)
        {
            animator.ResetTrigger("Jump");
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ��Ҵ��� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        // �÷��̾ ������ ������� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}
