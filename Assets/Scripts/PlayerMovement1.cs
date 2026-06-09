using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;
    public float jumpForce = 10f;

    [Header("Double Jump")]
    public int maxJumps = 2;

    private int jumpsRemaining;

    public bool canMove = true;

    private Rigidbody2D rb;
    private bool isGrounded;

    private bool isInvincible = false;
    public float invincibilityTime = 2f;

    private SpriteRenderer sr;
    private Animator animator;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        jumpsRemaining = maxJumps;
    }

    void Update()
    {
        float move = canMove ? Input.GetAxis("Horizontal") : 0f;

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("IsJumping", !isGrounded);

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (move > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }

        if (canMove &&
            Input.GetKeyDown(KeyCode.Space) &&
            jumpsRemaining > 0)
        {
            rb.linearVelocity =
                new Vector2(rb.linearVelocity.x, jumpForce);

            jumpsRemaining--;
        }

        if (transform.position.y < -10)
        {
            GameManager.instance.LoseLife();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;

            jumpsRemaining = maxJumps;
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }

    public void TakeDamage()
    {
        if (isInvincible)
            return;

        isInvincible = true;

        GameManager.instance.LoseLife();

        StartCoroutine(Blink());

        Invoke(nameof(EndInvincibility), invincibilityTime);
    }

    void EndInvincibility()
    {
        isInvincible = false;
    }

    IEnumerator Blink()
    {
        float timer = 0f;

        while (timer < invincibilityTime)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.15f);

            sr.enabled = true;
            yield return new WaitForSeconds(0.15f);

            timer += 0.3f;
        }

        sr.enabled = true;
    }
}