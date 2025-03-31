using UnityEngine;

public class Coin : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player")) // Verifica si el jugador toca la moneda
        {
            FindObjectOfType<CoinCounter>().AddCoin();

            Destroy(gameObject); // Elimina la moneda de la escena
        }
    }
}
