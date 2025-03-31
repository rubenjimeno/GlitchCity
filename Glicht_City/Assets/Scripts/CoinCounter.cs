using UnityEngine;
using TMPro; // Importa TextMeshPro

public class CoinCounter : MonoBehaviour
{
    public int coinCount = 0; // Contador de monedas
    public TMP_Text coinText; // Texto UI para mostrar el contador

    void Start()
    {
        UpdateCoinText();
    }

    public void AddCoin()
    {
        coinCount++; // Suma una moneda
        UpdateCoinText();
    }

    void UpdateCoinText()
    {
        if (coinText != null)
        {
            coinText.text = "Coleccionable: " + coinCount;
        }
    }
}
