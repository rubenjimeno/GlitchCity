using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 5; // Vida máxima del jugador
    private int currentHealth;
    public int CurrentHealth => currentHealth; // Para que el UI pueda acceder a la vida

    public delegate void HealthChanged(int currentHealth);
    public event HealthChanged OnHealthChanged; // Evento que se invoca cuando cambia la vida

    public AudioClip damageSound;  // Sonido que se reproduce cuando el jugador recibe daño
    private AudioSource audioSource;  // Referencia al AudioSource

    void Start()
    {
        currentHealth = maxHealth; // Inicializar vida
        audioSource = GetComponent<AudioSource>(); // Obtener el AudioSource del jugador
    }

    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        Debug.Log("Vida restante: " + currentHealth);

        // Reproducir sonido de daño
        if (audioSource != null && damageSound != null)
        {
            audioSource.PlayOneShot(damageSound); // Reproducir el sonido al recibir daño
        }

        if (currentHealth <= 0)
        {
            Die();
        }

        // Notificar a otros scripts que la vida ha cambiado
        OnHealthChanged?.Invoke(currentHealth);
    }

    void Die()
    {
        Debug.Log("El jugador ha muerto. Reiniciando escena...");
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reinicia la escena actual
    }
}
