using UnityEngine;

public class MedidorClick : MonoBehaviour
{
    private float tiempoInicio;
    private float tiempoPresionado;
    private bool estaPresionando = false;

    void Update()
    {
        // Al presionar click izquierdo
        if (Input.GetMouseButtonDown(0))
        {
            tiempoInicio = Time.time;
            estaPresionando = true;
            Debug.Log("Empezó a presionar...");
        }

        // Mientras mantiene presionado
        if (estaPresionando)
        {
            tiempoPresionado = Time.time - tiempoInicio;
        }

        // Al soltar click
        if (Input.GetMouseButtonUp(0))
        {
            estaPresionando = false;
            Debug.Log("Tiempo presionado: " + tiempoPresionado.ToString("F2") + " segundos");
        }
    }
}