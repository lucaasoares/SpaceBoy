using UnityEngine;

public class EnemyWalker : MonoBehaviour
{
    public float speed = 2f;

    private int direction = 1;
    private Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    void Update()
    {
        transform.Translate(
            Vector2.right * direction * speed * Time.deltaTime
        );
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Wall"))
        {
            direction *= -1;

            if (direction > 0)
            {
                transform.localScale = new Vector3(
                    Mathf.Abs(originalScale.x),
                    originalScale.y,
                    originalScale.z
                );
            }
            else
            {
                transform.localScale = new Vector3(
                    -Mathf.Abs(originalScale.x),
                    originalScale.y,
                    originalScale.z
                );
            }
        }
    }
}