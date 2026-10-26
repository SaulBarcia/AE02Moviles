using UnityEngine;
using TMPro; 

public class ScoreUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreText;

    void Start()
    {
        // Nos suscribimos al evento del servicio de puntuación
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged += UpdateScoreDisplay;
            UpdateScoreDisplay(ScoreManager.Instance.CurrentScore); // Valor inicial
        }
    }

    void OnDestroy()
    {
        // Cuando se destruye el objeto, desuscribimos la función para evitar memory leaks
        if (ScoreManager.Instance != null)
        {
            ScoreManager.Instance.OnScoreChanged -= UpdateScoreDisplay;
        }
    }

    void UpdateScoreDisplay(int newScore)
    {
        scoreText.text = "Distance: " + newScore + " m";
    }
}