using UnityEngine;

public class ScrollingBackground : MonoBehaviour
{
    public float speed = 1f;
    public float resetPositionX = -10f;
    public float moveAmount = 20f;
    private Vector3 startPos;

    void Start()
    {
        startPos = transform.position;
    }

    void Update()
    {
        transform.Translate(Vector3.left * speed * Time.deltaTime);

        if (transform.position.x < startPos.x - 18f)
        {
            transform.position = startPos;
        }
    }
}