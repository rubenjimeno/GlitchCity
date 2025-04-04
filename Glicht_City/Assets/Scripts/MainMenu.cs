using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necesario para las coroutines

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        StartCoroutine(LoadSceneWithDelay()); // Llamamos a la coroutine para cargar la escena con retraso
    }

    IEnumerator LoadSceneWithDelay()
    {
        yield return new WaitForSeconds(1f); // Espera 2 segundos (puedes cambiar este valor al que desees)
        SceneManager.LoadScene(1); // Carga la primera escena (verifica el índice en el Build Settings)
    }
}
