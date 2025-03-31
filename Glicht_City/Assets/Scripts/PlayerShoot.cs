using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;  // Punto desde donde se disparará el proyectil
    public float projectileSpeed = 10f;  // Velocidad del proyectil

    void Update()
    {
        if (Input.GetButtonDown("Fire1"))  // Disparar con el botón izquierdo del ratón
        {
            Shoot();
        }
    }

    void Shoot()
    {
        // Instanciar el proyectil en la posición del firePoint
        GameObject projectile = Instantiate(projectilePrefab, firePoint.position, firePoint.rotation);
        
        // Obtener el Rigidbody2D del proyectil y aplicarle velocidad
        Rigidbody2D rb = projectile.GetComponent<Rigidbody2D>();
        if (rb != null)
        {
            rb.linearVelocity = transform.right * projectileSpeed; // Hace que se mueva hacia la derecha
        }
    }
}
