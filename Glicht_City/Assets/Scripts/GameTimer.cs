using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro; // Importante para usar TextMeshPro

public class GameTimer : MonoBehaviour
{
    public float timeLimit = 30f; // Tiempo en segundos
    private float currentTime;
    public TextMeshProUGUI timerText; // Referencia al texto en pantalla

    void Start()
    {
        currentTime = timeLimit;
    }

    void Update()
    {
        currentTime -= Time.deltaTime; // Restar el tiempo cada frame
        timerText.text = "Tiempo: " + Mathf.Ceil(currentTime).ToString(); // Mostrar en pantalla

        if (currentTime <= 0)
        {
            RestartLevel();
        }
    }

    void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name); // Recarga la escena
    }
}
