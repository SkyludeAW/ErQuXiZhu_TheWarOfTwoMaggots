using UnityEngine;

public class PlayerController : MonoBehaviour {
    private Vector3 movement;
    private Rigidbody2D rb;

    public bool isGrounded;

    public float acceleration = 300f;
    public float deceleration = 300f;
    public float stopThreshold = 0.1f;
    public float maxSpeed = 5f;
    public float jumpForce = 300f;

    private void Awake() {
        rb = GetComponent<Rigidbody2D>();
        isGrounded = false;
    }

    // Update is called once per frame
    void Update() {
        movement.x = Input.GetAxis("Horizontal");
        movement.x = Mathf.Abs(movement.x) < 1 ? 0 : movement.x; 

        if (movement.x != 0) {
            rb.AddForceX(movement.normalized.x * acceleration * Time.deltaTime, ForceMode2D.Impulse);
        } else {
            if (Mathf.Abs(rb.linearVelocity.x) > stopThreshold && Mathf.Abs(rb.linearVelocity.x) > deceleration * Time.deltaTime) {
                rb.AddForceX(-Mathf.Sign(rb.linearVelocity.x) * deceleration * Time.deltaTime, ForceMode2D.Impulse);
            } else {
                rb.linearVelocity = new Vector2(0, rb.linearVelocity.y);
            }
        }

        if (Input.GetKeyDown(KeyCode.U)) {
            rb.AddForce(new Vector2(8192f, 0f), ForceMode2D.Impulse);
        }

        if (Mathf.Abs(rb.linearVelocity.x) > maxSpeed) {
            rb.linearVelocity = new Vector2(Mathf.Sign(rb.linearVelocity.x) * maxSpeed, rb.linearVelocity.y);
        }

        if (Input.GetButtonDown("Jump") && isGrounded) {
            rb.AddForceY(jumpForce);
            isGrounded = false;
        }
    }

    public void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.CompareTag("Ground")) {
            isGrounded = true;
        }
    }
}
