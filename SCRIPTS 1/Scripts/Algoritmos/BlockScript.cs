using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlockScript : MonoBehaviour
{
    public float lowerSpeed = 4.0f; // Velocidad a la que el bloque se baja.
    public float lowerLimit = -15.0f; // Altura mínima a la que el bloque puede descender.

    private bool isLowering = false;

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isLowering = true;
        }
    }

    private void Update()
    {
        if (isLowering && transform.position.y > lowerLimit)
        {
            // Baja gradualmente la posición en el eje Y.
            Vector3 newPosition = transform.position;
            newPosition.y -= lowerSpeed * Time.deltaTime;
            transform.position = newPosition;

            if (transform.position.y <= lowerLimit)
            {
                // Detiene el descenso cuando alcanza la altura mínima.
                isLowering = false;
            }
        }
    }
}
