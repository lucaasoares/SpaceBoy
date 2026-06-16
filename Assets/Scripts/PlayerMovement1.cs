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

    private float originalScaleX;
    private float originalScaleY;
    private float originalScaleZ;

    private bool isDead = false;

    // 🎧 Áudios
    private AudioSource jumpAudio;        // pulo normal
    private AudioSource doubleJumpAudio;  // pulo duplo
    private AudioSource footstepsAudio;
    private AudioSource damageAudio;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sr = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();

        jumpsRemaining = maxJumps;

        originalScaleX = Mathf.Abs(transform.localScale.x);
        originalScaleY = transform.localScale.y;
        originalScaleZ = transform.localScale.z;

        AudioSource[] audios = GetComponents<AudioSource>();

        if (audios.Length > 0)
            jumpAudio = audios[0];

        if (audios.Length > 1)
            doubleJumpAudio = audios[1];

        if (audios.Length > 2)
            footstepsAudio = audios[2];

        if (audios.Length > 3)
            damageAudio = audios[3];
    }

    void Update()
    {
        float move = canMove ? Input.GetAxis("Horizontal") : 0f;

        animator.SetFloat("Speed", Mathf.Abs(move));
        animator.SetBool("IsJumping", !isGrounded);

        rb.linearVelocity = new Vector2(move * speed, rb.linearVelocity.y);

        if (move > 0)
        {
            transform.localScale = new Vector3(originalScaleX, originalScaleY, originalScaleZ);
        }
        else if (move < 0)
        {
            transform.localScale = new Vector3(-originalScaleX, originalScaleY, originalScaleZ);
        }

        // Som dos passos
        if (footstepsAudio != null)
        {
            bool walking = Mathf.Abs(move) > 0.1f && isGrounded;

            if (walking)
            {
                if (!footstepsAudio.isPlaying)
                    footstepsAudio.Play();
            }
            else
            {
                if (footstepsAudio.isPlaying)
                    footstepsAudio.Stop();
            }
        }

        // 🎯 Pulo com diferenciação
        if (canMove && Input.GetKeyDown(KeyCode.Space) && jumpsRemaining > 0)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);

            // 👉 Verifica se é pulo normal ou duplo
            if (jumpsRemaining == maxJumps)
            {
                // PRIMEIRO PULO
                if (jumpAudio != null)
                {
                    jumpAudio.Stop();
                    jumpAudio.Play();
                }
            }
            else
            {
                // PULO DUPLO
                if (doubleJumpAudio != null)
                {
                    doubleJumpAudio.Stop();
                    doubleJumpAudio.Play();
                }
            }

            jumpsRemaining--;
        }

        // Caiu do mapa
        if (transform.position.y < -10 && !isDead)
        {
            StartCoroutine(FallDeath());
        }
    }

    IEnumerator FallDeath()
    {
        isDead = true;
        canMove = false;
        rb.linearVelocity = Vector2.zero;

        if (damageAudio != null)
        {
            damageAudio.Stop();
            damageAudio.Play();
        }

        float timer = 0f;

        while (timer < 0.5f)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.08f);

            sr.enabled = true;
            yield return new WaitForSeconds(0.08f);

            timer += 0.16f;
        }

        sr.enabled = true;

        if (GameManager.instance != null)
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
        if (isInvincible || isDead)
            return;

        StartCoroutine(DamageDeath());
    }

    IEnumerator DamageDeath()
    {
        isDead = true;
        isInvincible = true;
        canMove = false;

        if (damageAudio != null)
        {
            damageAudio.Stop();
            damageAudio.Play();
        }

        float timer = 0f;

        while (timer < 0.5f)
        {
            sr.enabled = false;
            yield return new WaitForSeconds(0.08f);

            sr.enabled = true;
            yield return new WaitForSeconds(0.08f);

            timer += 0.16f;
        }

        sr.enabled = true;

        if (GameManager.instance != null)
        {
            GameManager.instance.LoseLife();
        }
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