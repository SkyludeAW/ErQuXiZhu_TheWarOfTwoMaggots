using System;
using UnityEngine;

public class 随机效果 : MonoBehaviour
{
    private float RotationSpeed = 100f;
    private float DestroyTime = 5f;
    public static Action<随机效果> action;

    void Start()
    {
        Destroy(gameObject, DestroyTime);
    }


    void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime,Space.World);
    }

    void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Destroy(gameObject,0.1f);
                action?.Invoke(this);
        }
    }
}
