using UnityEngine;

public class attack2 : MonoBehaviour
{
    private float _lifetime = 0.1f;
    private float _timer = 0f;
    private void OnEnable()
    {
        _timer = _lifetime;
    }
    private void Update()
    {
        _timer -= Time.deltaTime;
        if (_timer <= 0f)
        {
            gameObject.SetActive(false);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player1"))
        {
            GameController.Instance.player1.HP -= 1f;
        }
    }
}
