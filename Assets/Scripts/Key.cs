using UnityEngine;

public class Key : MonoBehaviour
{
    private AudioSource audioSource;

    [Header("Float Settings")]
    public float floatSpeed = 1.2f;
    public float floatHeight = 0.15f;

    [Header("Rotation Settings")]
    public float rotationSpeed = 15f;

    [Header("Scale Pulse")]
    public float pulseSpeed = 2f;
    public float pulseAmount = 0.03f;

    private Vector3 startPosition;
    private Vector3 startScale; // 🔥 guarda o tamanho original

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        startPosition = transform.position;
        startScale = transform.localScale; // 🔥 salva o scale original
    }

    private void Update()
    {
        // 🔹 Flutuação
        float newY = startPosition.y + Mathf.Sin(Time.time * floatSpeed) * floatHeight;
        transform.position = new Vector3(startPosition.x, newY, startPosition.z);

        // 🔹 Rotação suave
        transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime, Space.World);

        // 🔹 Efeito de "respiração" (escala CORRIGIDO)
        float scaleMultiplier = 1 + Mathf.Sin(Time.time * pulseSpeed) * pulseAmount;
        transform.localScale = startScale * scaleMultiplier;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerKey playerKey = other.GetComponent<PlayerKey>();

            if (playerKey != null)
            {
                playerKey.hasKey = true;
            }

            // 🔊 Som da chave
            if (audioSource != null && audioSource.clip != null)
            {
                AudioSource.PlayClipAtPoint(
                    audioSource.clip,
                    Camera.main.transform.position,
                    1f);
            }

            Destroy(gameObject);
        }
    }
}