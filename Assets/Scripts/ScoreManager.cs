using UnityEngine;

public class ScoreManager : MonoBehaviour, IScoreService
{
    public static ScoreManager Instance { get; private set; }

    [Header("Configuración")]
    [SerializeField] private float worldSpeed = 10f;

    public int CurrentScore { get; private set; } = 0;
    public event System.Action<int> OnScoreChanged;

    private float accumulatedDistanceCm = 0f;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    void Update()
    {
        // 1. Calculamos la distancia recorrida en este frame (Velocidad * Tiempo)
        float distanceThisFrame = worldSpeed * Time.deltaTime;

        // 2. Convertimos a centímetros (1 unidad de Unity = 1 metro = 100 cm)
        accumulatedDistanceCm += distanceThisFrame * 100f;

        while (accumulatedDistanceCm >= 20f)
        {
            CurrentScore++;
            accumulatedDistanceCm -= 20f;

            // Notificamos a la UI
            OnScoreChanged?.Invoke(CurrentScore);
        }
    }
}