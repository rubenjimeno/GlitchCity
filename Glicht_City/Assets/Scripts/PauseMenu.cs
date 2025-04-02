using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject pausePanel; // Asigna el Panel de pausa en el Inspector
    private bool isPaused = false;

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) // Tecla para pausar
        {
            if (isPaused)
                ResumeGame();
            else
                PauseGame();
        }
    }

    public void PauseGame()
    {
        pausePanel.SetActive(true);
        Time.timeScale = 0f; // Pausa el tiempo del juego
        isPaused = true;
    }

    public void ResumeGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f; // Reactiva el tiempo del juego
        isPaused = false;
    }

    public void QuitGame()
    {
        Time.timeScale = 1f; // Asegura que el tiempo vuelve a la normalidad antes de salir
        SceneManager.LoadScene("MainMenu"); // Carga el menú principal (cambia el nombre si es necesario)
    }
}
