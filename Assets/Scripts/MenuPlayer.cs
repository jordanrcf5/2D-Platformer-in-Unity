using UnityEngine;
using UnityEngine.InputSystem; // 👈 New Input System

public class MenuPlayer : MonoBehaviour
{
    Rigidbody2D rb;
    Animator animator;
    SpriteRenderer spriteRenderer;
    float moveSpeed = 10f;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        // Read mouse position using the NEW Input System
        Vector2 mouseScreenPos = Mouse.current.position.ReadValue();
        Vector3 mouseWorldPos = Camera.main.ScreenToWorldPoint(mouseScreenPos);

        // Constrain movement to horizontal only
        mouseWorldPos.y = transform.position.y;
        mouseWorldPos.z = 0f;

        Vector2 direction = (mouseWorldPos - transform.position).normalized;

        // Apply movement using the correct Rigidbody2D property
        rb.linearVelocity = new Vector2(direction.x * moveSpeed, 0f);

        // Animation
        animator.SetFloat("magnitude", Mathf.Abs(rb.linearVelocity.x));

        // Flip sprite
        spriteRenderer.flipX = direction.x < 0;
    }
}
