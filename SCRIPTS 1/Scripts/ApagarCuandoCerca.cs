using UnityEngine;

public class ApagarCuandoCerca : MonoBehaviour
{
    public Transform entidadAControlar; // La entidad que se acerca
    public float distanciaUmbral = 5f; // La distancia a la que se apagar� la entidad
    public float tiempoApagado = 5f; // El tiempo que la entidad permanecer� apagada
    public GameObject light;
    private Renderer miRenderer; // El componente Renderer del objeto que se apagar�
    private bool estaApagado = false;
    private float tiempoApagadoRestante = 0f;

    void Start()
    {
        miRenderer = GetComponent<Renderer>();
        miRenderer.enabled = !estaApagado; // Asegurarse de que el Renderer est� en el estado correcto al inicio
    }

    void Update()
    {
        if (!estaApagado)
        {
            Vector3 posicionObjeto = transform.position;
            Vector3 posicionEntidad = entidadAControlar.position;

            // Calcula la distancia en el plano XZ (ignorando Y)
            float distanciaXZ = Vector2.Distance(new Vector2(posicionObjeto.x, posicionObjeto.z), new Vector2(posicionEntidad.x, posicionEntidad.z));

            if (distanciaXZ < distanciaUmbral)
            {
                // La entidad est� lo suficientemente cerca, ap�guela
                estaApagado = true;
                miRenderer.enabled = false;
                tiempoApagadoRestante = tiempoApagado;
                light.SetActive(false);
            }
        }
        else
        {
            // La entidad est� apagada, cuente el tiempo restante
            tiempoApagadoRestante -= Time.deltaTime;

            if (tiempoApagadoRestante <= 0)
            {
                // El tiempo de apagado ha terminado, encienda la entidad
                estaApagado = false;
                miRenderer.enabled = true;
                light.SetActive(true);
            }
        }
    }
}
