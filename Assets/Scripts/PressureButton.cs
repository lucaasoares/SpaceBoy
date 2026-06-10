using UnityEngine;

public class PressureButton : MonoBehaviour
{
    public GameObject trapDoor;

    private bool activated = false;

    private Vector3 originalScale;

    private void Start()
    {
        originalScale = transform.localScale;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (activated)
            return;

        if (other.CompareTag("Player"))
        {
            activated = true;

            // Afunda o botão
            transform.localScale =
                new Vector3(
                    originalScale.x,
                    originalScale.y * 0.5f,
                    originalScale.z);

            // Abre o alçapão
                TrapDoor door = trapDoor.GetComponent<TrapDoor>();

                if (door != null)
            {
                door.Open();
            }
        }
    }
}