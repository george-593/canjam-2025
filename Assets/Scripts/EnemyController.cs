using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class EnemyController : MonoBehaviour
{
    [Header("Movement Settings")]
    [SerializeField] private float speed = 1.0f;
    [SerializeField] private float hoverScaleSize = 1.2f;
    [SerializeField] private float rotationAmount = 0f;

    [Header("Randomization Settings")]
    [SerializeField] private float minWaitTime = 3f;
    [SerializeField] private float maxWaitTime = 5f;

    [Header("Odd One Out Settings")]
    public bool isOddOneOut = false;

    // Private variables
    private Rigidbody2D rb;
    private WinManager winManager;
    private Transform spriteRendererChild;
    private Vector2 direction = new Vector2(0, 0);
    private Vector3 initialScale = new Vector3();


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Get instances
        rb = GetComponent<Rigidbody2D>();
        winManager = GameObject.Find("WinManager").GetComponent<WinManager>();
        spriteRendererChild = GetComponentInChildren<SpriteRenderer>().transform;

        // Store the initial scale of the enemy
        initialScale = spriteRendererChild.localScale;

        // Change direction and start the direction coroutine
        changeRandomDirection();
        StartCoroutine(ChangeDirectionRoutine());
    }

    // Change direction when the enemy hits a wall or another player
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Border") || collision.gameObject.CompareTag("Enemy"))
        {
            direction = Vector2.Reflect(direction.normalized, collision.contacts[0].normal);
            rb.linearVelocity = direction * speed;
        }
    }

    // Wait for between minWaitTime and maxWaitTime
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

    // Turn to a random direction
    private void changeRandomDirection()
    {
        // Random movement
        float randomAngle = Random.Range(0f, 360f);
        float radians = randomAngle * Mathf.Deg2Rad;
        direction = new Vector2(Mathf.Cos(radians), Mathf.Sin(radians)).normalized;
        rb.linearVelocity = direction * speed;

        // Rotation
        rb.angularVelocity = rotationAmount;
    }

    // Detect when clicked on for win/loss calculation 
    void OnMouseDown()
    {
        if (isOddOneOut)
        {
            // Win UI, move onto next level
            winManager.OnWin();
        }
        else
        {
            // Deduct from lives left (https://github.com/george-593/canjam-2025/issues/14)
        }
    }

    // Increase child spriteRender size for hover effect
    void OnMouseEnter()
    {
        spriteRendererChild.localScale = new Vector3(hoverScaleSize, hoverScaleSize, 1f);
    }

    // Return to normal size
    void OnMouseExit()
    {
        spriteRendererChild.localScale = initialScale;
    }
}
