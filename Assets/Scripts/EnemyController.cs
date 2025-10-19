using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Header("Movement/Randomization Settings")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float minWaitTime = 3f;
    [SerializeField] private float maxWaitTime = 5f;

    [Header("Odd One Out Settings")]
    public bool isOddOneOut = false;

    // Private variables
    private Rigidbody2D rb;
    private WinManager winManager;
    private Vector2 direction = new Vector2(0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        winManager = GameObject.Find("WinManager").GetComponent<WinManager>();
        changeRandomDirection();

        StartCoroutine(ChangeDirectionRoutine());
    }

    // Turn around when the enemy hits a wall
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Enemy"))
        {
            direction = Vector2.Reflect(direction.normalized, collision.contacts[0].normal);
            rb.linearVelocity = direction * speed;
        }
    }

    private IEnumerator ChangeDirectionRoutine()
    {

        while (true)
        {
            // Wait for random amount of time
            float waitTime = Random.Range(minWaitTime, maxWaitTime);
            yield return new WaitForSeconds(waitTime);

            changeRandomDirection();
        }
    }

    private void changeRandomDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
        rb.linearVelocity = direction * speed;
    }

    void OnMouseDown()
    {
        if (isOddOneOut)
        {
            // Win UI, move onto next level
            winManager.OnWin();
        } else
        {
            // Deduct from lives left (https://github.com/george-593/canjam-2025/issues/14)
        }
    }
}
