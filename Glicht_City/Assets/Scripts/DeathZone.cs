using UnityEngine;
using UnityEngine.SceneManagement; // Necesario para reiniciar la escena

public class DeathZone : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si el jugador toca la zona de muerte
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Reiniciar nivel
        }
    }
}
