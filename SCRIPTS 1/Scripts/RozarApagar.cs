using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RozarApagar : MonoBehaviour
{
    public GameObject light;
    public AudioSource scareSound;
    public Collider collision;

    public Material offlight, onlight;
    public Renderer lightBulb;
    private bool estaApagado = false;
    public float tiempoApagadoRestante = 10.0f;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Ente"))
        {
            if (!estaApagado)
            {
                light.SetActive(false);
                collision.enabled = false;
                lightBulb.material = offlight;
                estaApagado = true;
                tiempoApagadoRestante = 10.0f; // Reiniciar el tiempo de apagado
            }
        }
    }

    void Update()
    {
        if (estaApagado)
        {
            // La entidad está apagada, cuente el tiempo restante
            tiempoApagadoRestante -= Time.deltaTime;

            if (tiempoApagadoRestante <= 0)
            {
                // El tiempo de apagado ha terminado, encienda la entidad
                estaApagado = false;
                light.SetActive(true);
                lightBulb.material = onlight;
                collision.enabled = true;
            }
        }
    }
}
