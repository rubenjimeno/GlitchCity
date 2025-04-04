using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip collectSound;  // Asigna el sonido en el Inspector
    private AudioSource audioSource;
    private bool collected = false;

    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (!collected && other.CompareTag("Player"))
        {
            collected = true;

            FindObjectOfType<CoinCounter>().AddCoin();

            // Reproduce el sonido
            if (audioSource != null && collectSound != null)
            {
                audioSource.PlayOneShot(collectSound);
            }
            else if (collectSound != null)
            {
                AudioSource.PlayClipAtPoint(collectSound, transform.position);
            }

            // Oculta la moneda mientras suena el sonido y la destruye después
            GetComponent<SpriteRenderer>().enabled = false;
            GetComponent<Collider2D>().enabled = false;
            Destroy(gameObject, 0.3f); // Espera a que termine el sonido
        }
    }
}