using UnityEngine;

public class CameraScaler : MonoBehaviour
{
    public float defaultAspectRatio = 16f / 9f; // Relación de aspecto predeterminada (16:9)

    void Start()
    {
        // Obtén la relación de aspecto de la pantalla actual
        float currentAspectRatio = (float)Screen.width / Screen.height;
        
        // Ajusta la cámara para mantener la relación de aspecto correcta
        Camera.main.aspect = currentAspectRatio;

        // Ajusta el tamaño ortográfico en función de la relación de aspecto
        if (currentAspectRatio < defaultAspectRatio)
        {
            // Si la relación de aspecto actual es más estrecha que la predeterminada, ajusta el tamaño ortográfico
            Camera.main.orthographicSize = 5f * (defaultAspectRatio / currentAspectRatio);
        }
        else
        {
            // Si la relación de aspecto actual es mayor o igual a la predeterminada, usa el tamaño predeterminado
            Camera.main.orthographicSize = 5f;
        }
    }
}
