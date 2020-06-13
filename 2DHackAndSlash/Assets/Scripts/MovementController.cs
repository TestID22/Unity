using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{
    Rigidbody2D rb;
    private Animator animator;

    public float horizontalSpeed = 40.0f;
    public float verticalSpeed = 30.0f;
    float speed;

    bool isGrounded;

    //Attack
    public Transform attackPoint; //берём позицию точки атаки.
    public float attackRange = 0.5f; //дистанция атаки.
    public LayerMask enemy;         // слой на который атака распротраняется
    public int attackDamage = 50;   // dmg lol

    //Ограничение ударов в секунду
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;


    //Жизни стартовые т.е максимальные, и текущие.
    public int maxHealth = 100;
    public int currentHealth;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;

    }

    void Update()
    {
       
    }
    void FixedUpdate()
    {
        transform.Translate(speed, 0f, 0f);
    }

    //Управление
    public void LeftButtonDown()
    {
        speed = -horizontalSpeed;
        animator.SetBool("isRunning", true);
        Vector3 theScale = transform.localScale;
        theScale.x = -147;
        transform.localScale = theScale;

    }
    public void RightButtonDown()
    {
        speed = +horizontalSpeed;
        animator.SetBool("isRunning", true);
        Vector3 theScale = transform.localScale;
        theScale.x = 147;
        transform.localScale = theScale;
    }
    public void OnClickJump()
    {
        if (isGrounded)
        {
            rb.AddForce(transform.up * verticalSpeed, ForceMode2D.Impulse);
        }
        isGrounded = false;
    }
    public void Stop()
    {
        speed = 0;
        animator.SetBool("isRunning", false);
    }

    //Проверка ОнГраунд
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
        }
    }

    
    //Блок Атаки
    public void Attack()
    {
        if(Time.time >= nextAttackTime)
        {
            nextAttackTime = Time.time + 1f / attackRate;
            animator.SetTrigger("Attack");
            Collider2D[] hitEmeny = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemy);
            foreach(Collider2D enemy in hitEmeny)
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }

        }

    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        if(currentHealth < 0)
        {
            Die();
        }
        
        Debug.Log($"I get {maxHealth - currentHealth} damage");
    }

    void Die()
    {
        Debug.Log("Im die");
    }
  
}