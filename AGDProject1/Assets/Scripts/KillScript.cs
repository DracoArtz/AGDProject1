using UnityEngine;

public class KillScript : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
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

