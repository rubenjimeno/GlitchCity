using UnityEngine;
using TMPro;  // Necesario para usar TextMeshPro

public class PlayerHealthUI : MonoBehaviour
{
    public TMP_Text healthText;  // Texto UI para mostrar la vida
    public PlayerHealth playerHealth;  // Referencia al script PlayerHealth

    void Start()
    {
        if (playerHealth != null)
        {
            playerHealth.OnHealthChanged += UpdateHealthText;  // Escuchar cambios en la vida
            UpdateHealthText(playerHealth.CurrentHealth);  // Mostrar la vida inicial
        }
    }

    void UpdateHealthText(int currentHealth)
    {
        if (healthText != null)
        {
            healthText.text = "Vida: " + currentHealth;
        }
    }
}
