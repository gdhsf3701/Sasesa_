using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float bulletSpeed = 5f;
    public float destroyDelay = 0.7f;
    private GameObject target; 

    void Start()
    {
       
        Destroy(gameObject, destroyDelay);

       
        target = GameObject.FindWithTag("Enemy");
        if (target != null)
        {
            
            Vector2 direction = (target.transform.position - transform.position).normalized;
            GetComponent<Rigidbody2D>().velocity = direction * bulletSpeed;
        }
    }

}
