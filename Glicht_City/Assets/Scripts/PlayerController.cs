using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f;  // Velocidad de movimiento
    public float jumpForce = 10f;  // Fuerza del salto
    private Rigidbody2D rb;  // Referencia al Rigidbody2D del jugador

    private bool isGrounded = false;  // Indica si el jugador está en el suelo

    public float leftLimit = -8f;  // Límite izquierdo de la escena
    public float rightLimit = 8f;  // Límite derecho de la escena

    public AudioClip jumpSound;  // Sonido del salto
    private AudioSource audioSource;  // Referencia al componente AudioSource

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        audioSource = GetComponent<AudioSource>();  // Obtiene el componente AudioSource
    }

    void Update()
    {
        // Movimiento horizontal
        float horizontalInput = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(horizontalInput * moveSpeed, rb.linearVelocity.y);

        // Limitar la posición en el eje X para que el jugador no se salga de los límites
        float clampedX = Mathf.Clamp(transform.position.x, leftLimit, rightLimit);
        transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);

        // Salto solo si está en el suelo
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);  // Salto

            // Reproducir el sonido de salto
            if (audioSource != null && jumpSound != null)
            {
                audioSource.PlayOneShot(jumpSound);  // Reproduce el sonido del salto
            }
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = true;
        }
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Ground"))
        {
            isGrounded = false;
        }
    }
}