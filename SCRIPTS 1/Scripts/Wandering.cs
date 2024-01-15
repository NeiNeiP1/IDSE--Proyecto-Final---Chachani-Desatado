using System.Collections;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float wanderingRadius = 10.0f; // Radio de deambulación.
    public float wanderingTime = 8.0f; // Tiempo entre cambios de dirección.
    public float wanderingSpeed = 3.0f; // Velocidad de deambulación.

    private Vector3 targetPosition;
    private float timer;

    void Start()
    {
        timer = wanderingTime;
        SetNewRandomDestination();
    }

    void Update()
    {
        if (timer <= 0 || Vector3.Distance(transform.position, targetPosition) < 1.0f)
        {
            SetNewRandomDestination();
        }
        else
        {
            // Reduce el temporizador.
            timer -= Time.deltaTime;
        }

        // Mueve el objeto hacia la posición de destino con la velocidad de deambulación.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, wanderingSpeed * Time.deltaTime);
    }

    void SetNewRandomDestination()
    {
        // Genera una nueva posición de destino dentro del radio de deambulación.
        Vector2 randomDirection = Random.insideUnitCircle * wanderingRadius;
        targetPosition = new Vector3(randomDirection.x, transform.position.y, randomDirection.y);

        // Reinicia el temporizador.
        timer = wanderingTime;
    }
}
