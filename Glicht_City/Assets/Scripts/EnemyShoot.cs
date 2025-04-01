using UnityEngine;
using System.Collections;

public class EnemyShoot : MonoBehaviour
{
    public GameObject projectilePrefab;
    public Transform firePoint;
    public float projectileSpeed = 5f;
    public float fireRate = 3f;

    void Start()
    {
        StartCoroutine(ShootRoutine());
    }

    // Coroutine para disparar cada cierto tiempo
    IEnumerator ShootRoutine()
    {
        while (true)
        {
            Shoot();
            yield return new WaitForSeconds(fireRate); // Espera entre disparos
        }
    }

    // Función para disparar el proyectil
    void Shoot()
    {
        // Instancia el proyectil en la posición y rotación del punto de disparo
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();

        // Asegúrate de que el Rigidbody2D esté presente
        if (rb != null)
        {
            rb.linearVelocity = -transform.right * projectileSpeed; // Mueve el proyectil hacia la izquierda
        }
    }

    // Detecta si el proyectil colisiona con algo
    public int damage = 1; // Daño que inflige el proyectil

    // Si el proyectil toca al jugador, le resta vida
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Si golpea al jugador
        {
            PlayerHealth playerHealth = other.GetComponent<PlayerHealth>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(damage); // Le resta vida al jugador
            }

            Destroy(gameObject); // Destruye el proyectil tras el impacto
        }
        else if (other.CompareTag("Ground")) // Si toca el suelo
        {
            Destroy(gameObject); // Destruye el proyectil al tocar el suelo
        }
    }
}