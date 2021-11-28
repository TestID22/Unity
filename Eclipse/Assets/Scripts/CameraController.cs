using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private float leftLimit;
    [SerializeField]
    private float rightLimit;

    [SerializeField]
    private float bottomLimit; 
    [SerializeField]
    private float upperLimit;



    public float smoothing = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if(transform.position != target.position)
        {
            Vector3 targetPosition = new Vector3(target.position.x, target.position.y, transform.position.z);
            transform.position = Vector3.Lerp(transform.position, targetPosition, smoothing);

            CameraVisibleArea();
        }
      
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
