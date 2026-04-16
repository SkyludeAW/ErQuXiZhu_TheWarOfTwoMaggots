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
        //GameController.Instance.player1.HP += 1;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector3.up * RotationSpeed * Time.deltaTime, Space.World);
    }


    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player1"))
        {
            action?.Invoke(this);
            Destroy(gameObject,0.1f);
            GameController.Instance.player1.HP += 1;
        }
        if (other.CompareTag("Player2"))
            {
                action?.Invoke(this);
                Destroy(gameObject,0.1f);
                GameController.Instance.player2.HP += 1;
        }
    }
}

    



