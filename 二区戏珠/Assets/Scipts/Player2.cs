using UnityEngine;

public class Player2 : MonoBehaviour
{
    private Vector3 movement;
    private Rigidbody2D rb;

    public bool isGrounded;

    public float acceleration = 300f;
    public float deceleration = 300f;
    public float stopThreshold = 0.1f;
    public float maxSpeed = 5f;
    public float jumpForce = 300f;

    public float HP = 10f;
    private float _attackTimer = 0f;
    private float _attackCooldown = 0.5f;
    [SerializeField] private GameObject _attackLeft;
    [SerializeField] private GameObject _attackRight;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }


    // Update is called once per frame
    void Update()
    {
        movement.x = Input.GetKey(KeyCode.LeftArrow) ? -1 : Input.GetKey(KeyCode.RightArrow) ? 1 : 0;
        if (movement.x != 0)
        {
            rb.AddForceX(movement.normalized.x * acceleration * Time.deltaTime, ForceMode2D.Impulse);
        }
        else
        {
            if (Mathf.Abs(rb.linearVelocity.x) > stopThreshold && Mathf.Abs(rb.linearVelocity.x) > deceleration * Time.deltaTime)
            {
                rb.AddForceX(-Mathf.Sign(rb.linearVelocity.x) * deceleration * Time.deltaTime, ForceMode2D.Impulse);
            }
            else
            {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.U))
        {
            rb.AddForce(new Vector2(8192f, 0f), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed)
        {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded)
        {
            rb.AddForceY(jumpForce);
            isGrounded = false;
        }

        _attackTimer -= Time.deltaTime;
        if (Input.GetKeyDown(KeyCode.Keypad1) && _attackTimer <= 0.0f)
        {
            _attackTimer = _attackCooldown;
            //Debug.Log("Player1 Attack!");
            _attackLeft.SetActive(true);
        }
        if (Input.GetKeyDown(KeyCode.Keypad2) && _attackTimer <= 0.0f)
        {
            _attackTimer = _attackCooldown;
            //Debug.Log("Player1 Attack!");
            _attackRight.SetActive(true);
        }
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}
