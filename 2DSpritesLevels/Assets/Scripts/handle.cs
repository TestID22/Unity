using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class handle : MonoBehaviour
{
    Rigidbody2D rb;
    public float horizontalSpeed = 0.03f;
    public float verticalSpeed = 0.07f;
    float speed;
    

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speed = -horizontalSpeed;
        } else if (Input.GetKey(KeyCode.D))
        {
            speed = +horizontalSpeed;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rb.AddForce(new Vector2(0, verticalSpeed), ForceMode2D.Impulse);
        }
        transform.Translate(speed, 0f, 0f);
        speed = 0;
    }
}
