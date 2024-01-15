using System.Collections;
using UnityEngine;

public class Wandering : MonoBehaviour
{
    public float wanderingRadius = 10.0f; // Radio de deambulaci�n.
    public float wanderingTime = 8.0f; // Tiempo entre cambios de direcci�n.
    public float wanderingSpeed = 3.0f; // Velocidad de deambulaci�n.

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

        // Mueve el objeto hacia la posici�n de destino con la velocidad de deambulaci�n.
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, wanderingSpeed * Time.deltaTime);
    }

    void SetNewRandomDestination()
    {
        // Genera una nueva posici�n de destino dentro del radio de deambulaci�n.
        Vector2 randomDirection = Random.insideUnitCircle * wanderingRadius;
        targetPosition = new Vector3(randomDirection.x, transform.position.y, randomDirection.y);

        // Reinicia el temporizador.
        timer = wanderingTime;
    }
}
