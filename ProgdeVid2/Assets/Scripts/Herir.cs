using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    [Header("Configuraci�n")]
    [SerializeField] int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica si el jugador est� tocando los lados
            if (EsColisionLateral(collision.transform))
            {
                Vida jugador = collision.gameObject.GetComponent<Vida>();
                jugador.ModificarVida(-puntos);
                Debug.Log("PUNTOS DE DA�O REALIZADOS AL JUGADOR " + puntos);
            }
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            if (EsColisionLateral(collision.transform))
            {
                Debug.Log("El jugador ha sido herido (Trigger)");
                Vida jugador = collision.GetComponent<Vida>();
                jugador.ModificarVida(-puntos);
            }
        }
    }

    // M�todo para comprobar si la colisi�n es lateral
    private bool EsColisionLateral(Transform jugadorTransform)
    {
        // Calcula la posici�n relativa entre el jugador y el enemigo
        Vector2 direccion = jugadorTransform.position - transform.position;

        // Imprime la direcci�n para depuraci�n
        Debug.Log($"Direcci�n relativa: {direccion}");

        // Eval�a si es colisi�n lateral
        float umbral = 0.5f; // Aumenta el umbral si es muy estricto
        bool esLateral = Mathf.Abs(direccion.y) < umbral && Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y);

        // Depuraci�n del resultado
        Debug.Log($"�Colisi�n lateral? {esLateral}");

        return esLateral;
    }
}