using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public AudioSource source;
    public AudioClip jumpSound;

    public float moveSpeed = 5f;
    public float jumpForce = 8f;

    private float h;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private bool facingLeft = false;
    private bool isGrounded = false;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        FlipPlayer();
    }

    void FixedUpdate()
    {
        rb2d.linearVelocity = new Vector2(h * moveSpeed, rb2d.linearVelocity.y);
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();
        h = input.x;
    }

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded)
        {
            source.PlayOneShot(jumpSound);
            rb2d.linearVelocity = new Vector2(rb2d.linearVelocity.x, 0f);
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
        }
    }

    void FlipPlayer()
    {
        if (spr == null) return;

        if ((h > 0 && facingLeft) || (h < 0 && !facingLeft))
        {
            facingLeft = !facingLeft;
            spr.flipX = facingLeft;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }
}