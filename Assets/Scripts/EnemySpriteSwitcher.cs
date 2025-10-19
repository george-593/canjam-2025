using UnityEngine;

public class BorderHitToAnim : MonoBehaviour
{
	[SerializeField] Animator animator;

	void Awake()
	{
		if (!animator) animator = GetComponent<Animator>();
	}
	void OnCollisionEnter2D(Collision2D col)
	{
		if (col.collider.CompareTag("Border") || col.collider.CompareTag("Enemy"))
			animator.SetTrigger("HitBorder");
	}
}