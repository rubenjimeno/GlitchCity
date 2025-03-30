using UnityEngine;

public class PlayerController : MonoBehaviour
{
    // Variables públicas (se pueden ajustar desde el Inspector)
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float rotationSpeed = 200f;  // Velocidad de rotación de la rueda
    public float jumpForce = 10f;  // Fuerza del salto

    // Variables privadas
    private Rigidbody2D rb;  // Referencia al Rigidbody2D
    private bool isGrounded = false;  // Para verificar si el personaje está tocando el suelo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtener el Rigidbody2D
    }

    void Update()
    {
        // Obtener el movimiento horizontal del jugador
        float move = Input.GetAxis("Horizontal");

        // Movimiento del personaje (solo afecta a la velocidad horizontal)
        rb.linearVelocity = new Vector2(move * moveSpeed, rb.linearVelocity.y); // Solo afecta la velocidad en X, no en Y

        // Rotación de la rueda solo cuando el personaje se mueve
        if (move != 0)
        {
            // Realizar la rotación solo si el personaje se está moviendo
            transform.Rotate(Vector3.forward * move * rotationSpeed * Time.deltaTime);
        }

        // Comprobar si el jugador presiona la tecla de salto
        if (isGrounded && Input.GetKeyDown(KeyCode.Space))
        {
            // Aplicar una fuerza hacia arriba para simular el salto
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
        }
    }

    // Detectar cuando el personaje toca el suelo
    void OnCollisionStay2D(Collision2D collision)
    {
        // Verificar si el objeto con el que colisiona tiene el tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;  // El personaje está tocando el suelo
        }
    }

    // Detectar cuando el personaje deja el suelo
    void OnCollisionExit2D(Collision2D collision)
    {
        // Verificar si el objeto con el que deja de colisionar tiene el tag "Ground"
        if (collision.gameObject.CompareTag("Ground"))
        {
            isGrounded = false;  // El personaje dejó de tocar el suelo
        }
    }
    void OnTriggerEnter2D(Collider2D collision)
{
    if (collision.gameObject.CompareTag("DeathZone"))
    {
        RestartPlayer();
    }
}

void RestartPlayer()
{
    transform.position = new Vector3(-2, 2, 0); // Cambia las coordenadas a la posición de reinicio
    rb.linearVelocity = Vector2.zero; // Detiene cualquier movimiento residual
}
}