using UnityEngine;

public class GolpearBola : MonoBehaviour
{
    public float fuerzaMaxima = 10f;
    public float tiempoMaximo = 2f;

    private float tiempoInicio;
    private float tiempoPresionado;
    private bool estaPresionando = false;
    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        // Rotar con A y D para apuntar
        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -100f * Time.deltaTime, 0);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 100f * Time.deltaTime, 0);
        }

        // Al presionar click
        if (Input.GetMouseButtonDown(0))
        {
            tiempoInicio = Time.time;
            estaPresionando = true;
            Debug.Log("Cargando golpe...");
        }

        // Mientras presiona
        if (estaPresionando)
        {
            tiempoPresionado = Time.time - tiempoInicio;
            tiempoPresionado = Mathf.Min(tiempoPresionado, tiempoMaximo);
        }

        // Al soltar click
        if (Input.GetMouseButtonUp(0))
        {
            estaPresionando = false;

            // Calcular fuerza
            float fuerzaAplicada = (tiempoPresionado / tiempoMaximo) * fuerzaMaxima;

            Debug.Log("Tiempo: " + tiempoPresionado.ToString("F2") + "s - Fuerza: " + fuerzaAplicada.ToString("F1"));

            // Aplicar fuerza hacia adelante
            rb.AddForce(transform.forward * fuerzaAplicada, ForceMode.Impulse);
        }
    }
}