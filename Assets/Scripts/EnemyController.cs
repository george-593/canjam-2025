using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float minWaitTime = 3f;
    public float maxWaitTime = 5f;

    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
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
}
