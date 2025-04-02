using UnityEngine;

public class Collectible : MonoBehaviour
{
    private LevelManager levelManager;

    void Start()
    {
        levelManager = FindObjectOfType<LevelManager>();  // Busca el script en la escena
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))  // Si el jugador lo recoge
        {
            levelManager.LoadNextLevel();  // Cambia de nivel
            Destroy(gameObject);  // Elimina el coleccionable
        }
    }
}
