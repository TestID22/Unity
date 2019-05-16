using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving : MonoBehaviour
{
    // Start is called before the first frame update
    public float horizantalSpeed;
    float speedX;
    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.A))
        {
            speedX = - horizantalSpeed;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            speedX = horizantalSpeed;
        }
        transform.Translate(speedX, 0, 0);
        speedX = 0;
    }
}
