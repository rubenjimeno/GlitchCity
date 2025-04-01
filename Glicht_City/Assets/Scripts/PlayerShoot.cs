using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject projectilePrefab;  // Prefab del proyectil
    public Transform firePoint;  // Punto desde donde se disparará el proyectil
    public float projectileSpeed = 10f;  // Velocidad del proyectil
    public float fireRate = 0.2f;  // Tiempo entre disparos

    private float nextFireTime = 0f;

    void Update()
    {
        // Comprobar si el tiempo actual es mayor al siguiente tiempo de disparo
        if (Input.GetButton("Fire1") && Time.time >= nextFireTime)  // Usa Fire1 (por defecto el clic izquierdo)
        {
            nextFireTime = Time.time + fireRate; // Establecer el siguiente tiempo de disparo
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
