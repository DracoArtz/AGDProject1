using UnityEngine;
using System.Collections;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class VolcanicVent : MonoBehaviour
{
    [Header("Timing")]
    public float activeTime = 3f;
    public float minDelay = 3f;
    public float maxDelay = 6f;

    [Header("State")]
    public bool isActive = false;

    private bool playerIsDying = false;

    public ParticleSystem ventParticles;
    public CameraShake camShake;


    public float shakeDuration = 0.3f;
    public float shakeMagnitude = 0.2f;
    private void Start()
    {
        StartCoroutine(VentCycle());
    }

    IEnumerator VentCycle()
    {
        while (true)
        {
            float waitTime = Random.Range(minDelay, maxDelay);
            yield return new WaitForSeconds(waitTime);

            isActive = true;

            if (ventParticles != null)
                ventParticles.Play();

            if (camShake != null)
                StartCoroutine(camShake.Shake(shakeDuration, shakeMagnitude));

            yield return new WaitForSeconds(activeTime);

            isActive = false;

            if (ventParticles != null)
                ventParticles.Stop();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (!isActive || playerIsDying) return;

        if (collision.CompareTag("Player"))
        {
            PlayerDeath death = collision.GetComponent<PlayerDeath>();

            if (death != null)
            {
                StartCoroutine(death.KillPlayer());
            }
        }
    }

    IEnumerator KillPlayer(GameObject player)
    {
        playerIsDying = true;
        PlayerInput input = player.GetComponent<PlayerInput>();
        if (input != null)
        {
            input.enabled = false;
        }

        SpriteRenderer sr = player.GetComponentInChildren<SpriteRenderer>();
        if (sr != null)
        {
            sr.color = Color.red;
        }

        yield return new WaitForSeconds(2f);

        SceneManager.LoadScene(0);
    }
}