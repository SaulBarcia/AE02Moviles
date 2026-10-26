using UnityEngine;
using UnityEngine.UI;

public class CarController : MonoBehaviour
{
    [Header("Referencias UI")]
    public Slider controlSlider;
    public GameObject MenuDeath;
    [Header("Configuración de Movimiento")]
    public float anchoCarretera = 5f; // Distancia máxima desde el centro hacia un lado 
    public float velocidadMovLateral = 10f; // Velocidad de suavizado del movimiento

    void Start()
    {
        MenuDeath.SetActive(false); 
    }

    void Update()
    {
        if (controlSlider == null) return;

       
        float targetX = controlSlider.value * anchoCarretera;

        // 2. Mantener la posición actual Y y Z del coche
        Vector3 targetPosition = new Vector3(targetX, transform.position.y, transform.position.z);

        // 3. Mover suavemente el coche hacia la posición objetivo (Lerp)
        transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * velocidadMovLateral);
    }
    void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "ObstacleCollision")
        {
            Time.timeScale = 0f;
            MenuDeath.SetActive(true);
        }
    }
}