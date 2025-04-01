using UnityEngine;

public class Projectile : MonoBehaviour
{
    public int damage = 1;  // Daño que hace el proyectil
    public float speed = 10f;  // Velocidad del proyectil

    void Start()
    {
        Rigidbody2D rb = GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.right * speed;  // Hacer que el proyectil se mueva
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        // Si el proyectil toca al enemigo
        if (other.CompareTag("Enemy"))
        {
            Debug.Log("El proyectil tocó al enemigo");
            EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();  // Obtener el script de salud del enemigo

            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damage);  // Hacerle daño al enemigo
            }
            else
            {
                Debug.LogWarning("EnemyHealth no encontrado en el enemigo");
            }

            Destroy(gameObject);  // Destruir el proyectil inmediatamente
        }

        // Si el proyectil toca el suelo o un objeto con el tag "Ground"
        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);  // Destruir el proyectil inmediatamente
        }
    }
}