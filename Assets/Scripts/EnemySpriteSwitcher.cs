using UnityEngine;

public class BorderHitToAnim : MonoBehaviour
{
    [SerializeField] Animator animator;

    [SerializeField] string walkUpTrigger = "TWalkUp";
    [SerializeField] string walkDownTrigger = "TWalkDown";
    [SerializeField] string walkLeftTrigger = "TWalkLeft";

    // Walking up threshold before triggering walk up animation.
    [SerializeField] float walkUpThreshold = 0.1f;

    // Walking down threshold before triggering walk down animation.
    [SerializeField] float walkDownThreshold = -0.1f;

    // Walking left threshold before triggering walk left animation.
    [SerializeField] float walkLeftThreshold = -0.1f;

    [SerializeField] bool watchRigidbody = true;

    Rigidbody2D rb;
    bool wasWalkingUp;
    bool wasWalkingDown;

    void Awake()
    {
        if (!animator) animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (watchRigidbody && rb != null)
        {
            Vector2 vel = rb.linearVelocity;
            CheckAndTriggerWalkUp(vel);
            CheckAndTriggerWalkDown(vel);
            CheckAndTriggerWalkLeft(vel);
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.collider.CompareTag("Border") || col.collider.CompareTag("Enemy"))
            animator?.SetTrigger("HitBorder");
    }




    void CheckAndTriggerWalkUp(Vector2 movement)
    {
        bool isWalkingUp = movement.y > walkUpThreshold;

        if (isWalkingUp && !wasWalkingUp)
        {
            if (animator != null && !string.IsNullOrEmpty(walkUpTrigger))
                animator.SetTrigger(walkUpTrigger);
        }

        wasWalkingUp = isWalkingUp;
    }

    void CheckAndTriggerWalkDown(Vector2 movement)
    {
        bool isWalkingDown = movement.y < walkDownThreshold;

        if (isWalkingDown && !wasWalkingDown)
        {
            if (animator != null && !string.IsNullOrEmpty(walkDownTrigger))
                animator.SetTrigger(walkDownTrigger);
        }

        wasWalkingDown = isWalkingDown;
    }

    void CheckAndTriggerWalkLeft(Vector2 movement)
    {
        if (movement.x < walkLeftThreshold)
        {
            if (animator != null && !string.IsNullOrEmpty(walkLeftTrigger))
                animator.SetTrigger(walkLeftTrigger);
        }
    }
}


