using UnityEngine;

public class ProjectileDamage : MonoBehaviour
{
    public int damage = 1; // El daño que hace el proyectil

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si colisiona con el jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>(); // Obtiene el script de salud del jugador

            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Resta vida al jugador
            }

            Destroy(gameObject); // Destruye el proyectil después del impacto
        }
        else if (other.CompareTag("Ground")) // Si colisiona con el suelo
        {
            Destroy(gameObject); // Destruye el proyectil al tocar el suelo
        }
    }
} 