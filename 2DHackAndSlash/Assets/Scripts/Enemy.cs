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
    //на сколько отпрыгивает при ударе
    public float jumpBack = 3.0f;
    [SerializeField]
    float horizontalSpeed = 3.0f;

    //
    public LayerMask playerMask;

    //FindPlayer position для того, чтобы идти к нему
    GameObject playerPos;

    //Atack
    public float attackRange = 3.0f;
    public int enemyDamage = 50;
    public Transform attackPoint;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        currentHealth = maxHealth;
        playerPos = GameObject.FindGameObjectWithTag("Player");
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, playerPos.transform.position, Time.deltaTime * horizontalSpeed);
        Attack();
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
        Debug.Log($"I take {maxHealth - currentHealth} damage");
    }
    void Die()
    {
        //Animate Die/ anim.SetBool("isDead", true); 
        Debug.Log("Im dying");
        anim.SetBool("isDead", true);
        GetComponent<Collider2D>().enabled = false;
        Destroy(gameObject);
    }


    void Attack()
    {
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, playerMask);
        foreach (Collider2D collider in allColliders)
        {
            Debug.Log("Ecть");
            collider.GetComponent<MovementController>().TakeDamage(enemyDamage);
        }
        
    }


}
