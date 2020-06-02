using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class evil_attack : MonoBehaviour
{
    Rigidbody2D rb;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    
    void Update()
    {
        transform.Translate(0.1f, 0, 0);
    }
}
