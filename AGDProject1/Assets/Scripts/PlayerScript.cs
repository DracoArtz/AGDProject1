using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerScript : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float h;
    public float v;

    private Vector2 dir;
    private Rigidbody2D rb2d;
    private SpriteRenderer spr;
    private bool facingLeft = false;

    public float jumpForce = 8f;
    private bool isGrounded = true;

    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        spr = GetComponent<SpriteRenderer>();

        Debug.Log("Start ran");
        Debug.Log("Rigidbody2D found? " + (rb2d != null));
        Debug.Log("SpriteRenderer found? " + (spr != null));
    }

    void Update()
    {
        FlipPlayer();
    }

    void FixedUpdate()
    {
        if (rb2d == null) return;

        rb2d.MovePosition(rb2d.position + dir * moveSpeed * Time.fixedDeltaTime);
    }

    public void MovePlayer(InputAction.CallbackContext ctx)
    {
        Vector2 input = ctx.ReadValue<Vector2>();

        h = input.x;
        v = input.y;
        dir = input.normalized;

        Debug.Log("MovePlayer called. Input = " + input);
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

    public void Jump(InputAction.CallbackContext ctx)
    {
        if (ctx.performed && isGrounded)
        {
            rb2d.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            isGrounded = false;
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