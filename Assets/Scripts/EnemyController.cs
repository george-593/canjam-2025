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

    // Update is called once per frame
    //
    void Update()
    {
        
    }

    // Turn around when the enemy hits a wall
    void OnCollisionEnter2D(Collision2D collision)
    {

    }
    
    private void ChangeDirection()
    {
        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
        rb.linearVelocity = direction * speed;
    }
}
