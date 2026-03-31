using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class GroundFallingScript : MonoBehaviour
{
    bool falling = false;
    int yVal = 0;
    public float fallSpeed;
    public float waitTime;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(falling)
        {
            transform.Translate(new Vector2(0, yVal - fallSpeed));
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(Wait());
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(waitTime);
        falling = true;

    }
}
