using UnityEngine;

public class SeaMonster : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed = 2f;

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerDeath death = collision.GetComponent<PlayerDeath>();

            if (death != null)
            {
                StartCoroutine(death.KillPlayer());
            }
        }
    }
}