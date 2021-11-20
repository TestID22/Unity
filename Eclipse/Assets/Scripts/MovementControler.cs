using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControler : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;
    private bool facingRight = true;

    public Joystick joy;
    public ControlType controlType;
    public Animator _animator;
    public enum ControlType { PC, Android }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));

        }
        else if(controlType == ControlType.Android)
        {
            moveInput = new Vector2(joy.Horizontal, joy.Vertical);
        }
        moveVelocity = moveInput.normalized * speed;

        if(!facingRight && moveInput.x > 0)
        {
            Flip();

        }else if(facingRight && moveInput.x < 0)
        {
            Flip();
        }
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
    }

    private void Flip()
    {
        facingRight = !facingRight;
        Vector3 scaler = transform.localScale;
        scaler.x *= -1;
        transform.localScale = scaler;

    }
}
