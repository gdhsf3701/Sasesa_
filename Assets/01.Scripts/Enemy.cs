using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    public int maxHealth = 3;
    private int currentHealth;


    Vector2 moveDir;
    public float speed = 5f;
    public float chaseRange = 10f;
    SpriteRenderer spriteRenderer;
    public GameObject player;
    Rigidbody2D rigid;

    private void Start()
    {
     
        currentHealth = maxHealth; // Ã¼·Â
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        //moveDir = new Vector3 (player.transform.position - transform.position);
          
        
        if(currentHealth == 0)
        {
            Die();
            
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Effect"))
        {
            StartCoroutine(damage());
            currentHealth--;
        }
        if (collision.gameObject.CompareTag("Bullet"))
        {
            StartCoroutine(damage());
        }
    }

    private void FixedUpdate()
    {
        
    }



    void Die()
    {
        Destroy(gameObject);
    }
    IEnumerator damage()
    {
        spriteRenderer.color = Color.red;
        yield return new WaitForSeconds(1);
        spriteRenderer.color = Color.white;
    }
}

