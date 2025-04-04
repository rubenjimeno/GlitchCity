using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathZone : MonoBehaviour
{
    private AudioSource audioSource;
    public AudioClip deathSound;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>(); // Añade uno si no existe
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (deathSound != null)
            {
                audioSource.PlayOneShot(deathSound);
            }

            // Reinicia el nivel tras un pequeño retraso para que el sonido se escuche
            Invoke("ReloadScene", 0.5f);
        }
    }

    void ReloadScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
