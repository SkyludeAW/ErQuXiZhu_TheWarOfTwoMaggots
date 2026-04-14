using System;
using UnityEngine;

public class 效果触发 : MonoBehaviour
{
    private float RotationSpeed = 100f;
    private float DestroyTime = 5f;
    public static Action<效果触发> action;
    void Start()
    {
        Destroy(gameObject, DestroyTime);
     
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime, Space.World);
    }


    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject, 0.1f);
            action?.Invoke(this);
        }
    }
}

    



