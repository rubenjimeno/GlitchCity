using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void PlayGame()
    {
        SceneManager.LoadScene(1); // Carga la primera escena (verifica el índice en el Build Settings)
    }
}
