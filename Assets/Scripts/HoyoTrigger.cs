using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class HoyoTrigger : MonoBehaviour
{
    public float tiempoEspera = 1f;
    public bool esUltimoNivel = false; // NUEVO: marca si es el último nivel

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine(CambiarEscenaConDelay());
        }
    }

    IEnumerator CambiarEscenaConDelay()
    {
        yield return new WaitForSeconds(tiempoEspera);

        // Si es el último nivel
        if (esUltimoNivel)
        {
            Debug.Log("¡GANASTE! SE ACABÓ EL JUEGO");
            // Opcionalmente detener el juego:
            Time.timeScale = 0;
        }
        else
        {
            // Cargar siguiente nivel
            int escenaActual = SceneManager.GetActiveScene().buildIndex;
            SceneManager.LoadScene(escenaActual + 1);
        }
    }
}