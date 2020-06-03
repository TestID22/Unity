using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    Rigidbody2D rb;
    public Animator anim;
    public int maxHealth = 100;
    int currentHealth;

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
        this.enabled = false;
        GetComponent<Collider2D>().enabled = false;
    }
}
