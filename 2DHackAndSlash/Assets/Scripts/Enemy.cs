using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;
    public float jumpBack = 3.0f;

    public LayerMask player;
    private float verticalSpeed;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
    }

    
    void Update()
    {

    }

    public void TakeDamage(int damage)
    {
        transform.Translate(jumpBack, 0, 0);
        anim.SetTrigger("isHurt");
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Die();
        }
    }
    void Die()
    {
        //Animate Die/ anim.SetBool("isDead", true); 
        Debug.Log("Im dying");
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }


}
