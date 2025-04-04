using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections; // Necesario para las coroutines

public class LevelManager : MonoBehaviour
{
    public void LoadNextLevel()
    {
        StartCoroutine(LoadNextLevelWithDelay()); // Llamamos a la coroutine que agrega el retraso
    }

    IEnumerator LoadNextLevelWithDelay()
    {
        yield return new WaitForSeconds(1f); // Espera 1 segundo antes de cargar el siguiente nivel
        
        int nextSceneIndex = SceneManager.GetActiveScene().buildIndex + 1;
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex); // Carga el siguiente nivel
        }
        else
        {
            Debug.Log("No hay más niveles disponibles.");
        }
    }
}
