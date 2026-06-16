using UnityEngine;
using System.Collections;

public class TrapDoor : MonoBehaviour
{
    private AudioSource audioSource;

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void Open()
    {
        StartCoroutine(OpenTrapDoor());
    }

    private IEnumerator OpenTrapDoor()
    {
        // Libera a passagem imediatamente
        GetComponent<BoxCollider2D>().enabled = false;

        // Tempo antes de abrir
        yield return new WaitForSeconds(1f);

        // Toca o som
        if (audioSource != null && audioSource.clip != null)
        {
            audioSource.Play();
        }

        // Some visualmente no MESMO momento do som
        SpriteRenderer sr = GetComponent<SpriteRenderer>();

        if (sr != null)
        {
            sr.enabled = false;
        }

        // Espera o som terminar para destruir o objeto
        if (audioSource != null && audioSource.clip != null)
        {
            yield return new WaitForSeconds(audioSource.clip.length);
        }

        Destroy(gameObject);
    }
}