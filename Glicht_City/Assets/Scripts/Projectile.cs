using UnityEngine;

public class Projectile : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground")) // Si choca con un objeto con el tag "Ground"
        {
            Destroy(gameObject); // Eliminar el proyectil
        }
    }
}
