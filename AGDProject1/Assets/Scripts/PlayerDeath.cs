using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerDeath : MonoBehaviour
{
    private bool isDying = false;

    public IEnumerator KillPlayer()
    {
        if (isDying) yield break;
        isDying = true;

        SpriteRenderer sr = GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.red;
        }

        PlayerInput input = GetComponent<PlayerInput>();
        if (input != null)
        {
            input.enabled = false;
        }

        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = Vector2.zero;
            rb.bodyType = RigidbodyType2D.Static;
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}