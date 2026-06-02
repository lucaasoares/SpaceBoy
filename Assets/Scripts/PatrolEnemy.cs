using UnityEngine;

public class PatrolEnemy : MonoBehaviour
{
    public float speed = 2f;

    private int direction = 1;

    void Update()
    {
        transform.Translate(Vector2.right * direction * speed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Wall"))
        {
            direction *= -1;
        }
    }
}