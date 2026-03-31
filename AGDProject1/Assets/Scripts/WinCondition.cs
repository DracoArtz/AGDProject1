using UnityEngine;

public class WinCondition : MonoBehaviour
{
    public GameObject winText;
    private void Start()
    {
        winText.SetActive(false);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            winText.SetActive(true);
            Debug.Log("You win");
        }
    }
}