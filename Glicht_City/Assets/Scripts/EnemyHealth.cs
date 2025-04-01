using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth = 5;
    private int currentHealth;

    void Start()
    {
        currentHealth = maxHealth;  // Inicializa la salud
    }

    public void TakeDamage(int damage)
    {
        // Asegurarnos de que el daño no sea negativo
        if (damage <= 0)
        {
            Debug.LogWarning("Daño negativo recibido");
            return;
        }

        currentHealth -= damage;
        Debug.Log("Vida restante del enemigo: " + currentHealth);

        // Comprobar si la salud llega a 0 o menos
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("El enemigo ha muerto.");
        Destroy(gameObject);  // Destruir el objeto cuando el enemigo muere
    }
}