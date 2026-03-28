using UnityEngine;

public class SeaMonster : MonoBehaviour
{
    public Rigidbody2D rb;
    [SerializeField] private float speed = 2f;

    void FixedUpdate()
    {
        rb.linearVelocity = Vector2.right * speed;
    }
}
