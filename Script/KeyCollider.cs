using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyCollider : MonoBehaviour
{
    public Text llavesText; // Referencia al objeto Text en tu Canvas
    public int puntosGanados = 0; // Cantidad de puntos que se ganan al colisionar con el cofre

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            // Asegúrate de que "Player" sea la etiqueta correcta para tu jugador
            // Puedes establecer la etiqueta en el Inspector de Unity.

            // Incrementa la cantidad de puntos
            int puntosActuales = int.Parse(llavesText.text);
            puntosActuales += puntosGanados;
            llavesText.text = puntosActuales.ToString();

            // Desactiva el cofre para que desaparezca
            gameObject.SetActive(false);
        }
    }
}

