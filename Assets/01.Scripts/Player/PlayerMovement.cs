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
        float h = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(h * moveSpeed, rb.velocity.y);

        if (h > 0)
        {
            transform.localScale = new Vector3(1, 1, 1); // ������
        }
        else if (h < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1); // ����
        }

        if (Input.GetButtonDown("Jump") && !animator.GetBool("Jump"))
        {
            Jump();
        }

        // �ȱ� �ִϸ��̼� ����
        if (h != 0 && isGrounded)
        {
            animator.SetBool("Walk", true);
        }
        else
        {
            animator.SetBool("Walk", false);
        }

        
    }
    void Jump()
    {
        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
        isGrounded = false; // 2�� ���� ����
        animator.SetBool("Jump", true);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        // �÷��̾ ���� ��Ҵ��� Ȯ��
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
            animator.SetBool("Jump", false);
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
