using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionMessage : MonoBehaviour
{
    public Image messageImage;
    public Text llavesText;   // La imagen que contiene el Text para mostrar el mensaje.
    public GameObject puerta1;  // Arrastra el Prefab de la primera puerta aquí.
    public GameObject puerta2;


    private void Start()
    {
        // Asegúrate de que la imagen esté desactivada al inicio del juego.
        if (messageImage != null)
        {
            messageImage.gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        // Verificar las etiquetas de los objetos con los que colisiona.
        if (other.gameObject.CompareTag("Player"))
        {
            // Mostrar un mensaje específico cuando colisiona con la etiqueta "Ayuda".
            int puntosActuales = int.Parse(llavesText.text);
            if (puntosActuales < 5 )
            {
                MostrarMensaje("  AVISO: \n Recolecta los 5 cofres y llevalas la centro, para poder abrir la puerta al templo");
            } else {
                MostrarMensaje("  AVISO: \n Las puertas al templo han sido abiertas");
                RotarPuerta1();
                RotarPuerta2();
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        // Cuando el jugador sale del área de colisión, oculta el mensaje.
        OcultarMensaje();
    }

    // Método para mostrar un mensaje en la imagen.
    private void MostrarMensaje(string mensaje)
    {
        if (messageImage != null)
        {
            // Accede al componente Text desde la Image y establece el texto.
            Text messageText = messageImage.GetComponentInChildren<Text>();
            if (messageText != null)
            {
                messageText.text = mensaje;
                messageImage.gameObject.SetActive(true);
            }
        }
    }

    // Método para ocultar el mensaje en la imagen.
    private void OcultarMensaje()
    {
        if (messageImage != null)
        {
            messageImage.gameObject.SetActive(false);
        }
    }

    // Por ejemplo, para rotar la primera puerta 90 grados en el eje Y:
    public void RotarPuerta1()
    {
        puerta1.transform.Rotate(Vector3.up, 90f);
        // puerta1.SetActive(false);
    }

    // Y para rotar la segunda puerta -90 grados en el eje Y:
    public void RotarPuerta2()
    {
        puerta2.transform.Rotate(Vector3.up, -90f);
        // puerta2.SetActive(false);
    }
}
