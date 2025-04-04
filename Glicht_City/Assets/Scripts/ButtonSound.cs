using UnityEngine;
using UnityEngine.UI;

public class ButtonSound : MonoBehaviour
{
    public AudioClip buttonClickSound;  // El sonido del botón
    private AudioSource audioSource;    // El componente AudioSource

    void Start()
    {
        // Obtiene el componente AudioSource
        audioSource = GetComponent<AudioSource>();
        
        // Asegúrate de que el componente AudioSource esté presente
        if (audioSource == null)
        {
            audioSource = gameObject.AddComponent<AudioSource>();  // Si no lo tiene, lo añadimos
        }
    }

    public void OnButtonClick()
    {
        // Reproducir el sonido cuando el botón sea presionado
        if (audioSource != null && buttonClickSound != null)
        {
            audioSource.PlayOneShot(buttonClickSound);
        }
    }
}
