using UnityEngine;

public class ResetBola : MonoBehaviour
{
    public Transform puntoSpawn;
    private Rigidbody rb;
    private Quaternion rotacionInicial;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        // Guardar rotación inicial
        rotacionInicial = transform.rotation;
    }

    void Update()
    {
        // Al soltar Espacio, resetear posición Y rotación
        if (Input.GetKeyUp(KeyCode.Space))
        {
            transform.position = puntoSpawn.position;
            transform.rotation = rotacionInicial; // ← ESTO ES NUEVO
            rb.velocity = Vector3.zero;
            rb.angularVelocity = Vector3.zero;
            Debug.Log("Bola reseteada (posición y rotación)");
        }
    }
}