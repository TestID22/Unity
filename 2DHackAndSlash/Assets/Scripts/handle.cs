using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    Rigidbody2D rb;
    public float horizontalSpeed = 0.03f;
    public float verticalSpeed = 0.07f;
    float speed;
    bool isGrounded;
    private Animator animator;

    //Attack
    public Transform attackPoint;
    public float attackRange = 0.5f;
    public LayerMask enemy;
    public int attackDamage = 50;

    //Ограничение ударов в секунду
    public float attackRate = 2.0f;
    float nextAttackTime = 0f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

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

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
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

    

    //Управление под ПК
    //private void ComputerHandle()
    //{
    //    if (Input.GetKey(KeyCode.A))
    //    {
    //        speed = -horizontalSpeed;
    //    }
    //    else if (Input.GetKey(KeyCode.D))
    //    {
    //        speed = +horizontalSpeed;
    //    }
    //    if (Input.GetKeyDown(KeyCode.Space))
    //    {
    //        rb.AddForce(new Vector2(0, verticalSpeed), ForceMode2D.Impulse);
    //    }
    //    transform.Translate(speed, 0f, 0f);
    //    speed = 0;
    //}
}