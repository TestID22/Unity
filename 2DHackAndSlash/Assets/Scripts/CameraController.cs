using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    float leftLimit;
    [SerializeField]
    float rightLimit;
    [SerializeField]
    float bottomLimit;
    [SerializeField]
    float upperLimit;
    void Start()
    {
        
    }

    void Update()
    {
        CameraVisibleArea();
    }


    void CameraVisibleArea()
    {
        //Мат. функция первый параметр область работы, измерение второй и третий ограничение области по оси x и
        transform.position = new Vector3(
            Mathf.Clamp(transform.position.x, leftLimit, rightLimit),
            Mathf.Clamp(transform.position.y, bottomLimit, upperLimit),
           transform.position.z
            );
    }

}
