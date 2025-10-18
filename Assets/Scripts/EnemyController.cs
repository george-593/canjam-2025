using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    public float speed = 1.0f;
    public float changeDirectionRate = 1.0f;

    private Rigidbody2D rb;
    private Vector2 direction = new Vector2(0, 0);


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        InvokeRepeating(nameof(ChangeDirection), 0f, changeDirectionRate);
    }

    // Turn around when the enemy hits a wall
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Enemy"))
        {
            direction = new Vector2(direction.x * -1, direction.y * -1);
            rb.linearVelocity = direction * speed;
        }
    }
    
    private void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
        rb.linearVelocity = direction * speed;
    }
}
