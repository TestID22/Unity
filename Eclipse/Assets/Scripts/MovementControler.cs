using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementControler : MonoBehaviour
{
    [SerializeField] private float speed;
    private Rigidbody2D rb;
    private Vector2 moveInput;
    private Vector2 moveVelocity;

    public Joystick joy;
    public ControlType controlType;
    public Animator _animator;
    public enum ControlType { PC, Android }

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        _animator = GetComponent<Animator>();
        joy.DeadZone = 0.5f;
    }

    private void Update()
    {
        if (controlType == ControlType.PC)
        {
            moveInput = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        }
        else if (controlType == ControlType.Android)
        {
            moveInput = new Vector2(joy.Horizontal, joy.Vertical);
        }
        moveVelocity = moveInput.normalized * speed;

    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + moveVelocity * Time.deltaTime);
        if (moveInput.x > 0.0f)
        {
            Movement(1);
            _animator.SetBool("is_running", true);
            
        }
        else if (moveInput.x < 0.0f)
        {
            Movement(-1);
            _animator.SetBool("is_running", true);

        }
        else
        {
            _animator.SetBool("is_running", false);

        }

    }

    private void Movement(int directiom)
    {
        Vector3 flip = transform.localScale;
        flip.x = directiom;
        transform.localScale = flip;
    }



}
