using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Herir : MonoBehaviour
{
    [Header("Configuración")]
    [SerializeField] int puntos = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Verifica si el jugador está tocando los lados
            if (EsColisionLateral(collision.transform))
            {
                Vida jugador = collision.gameObject.GetComponent<Vida>();
                jugador.ModificarVida(-puntos);
                Debug.Log("PUNTOS DE DAÑO REALIZADOS AL JUGADOR " + puntos);
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

    // Método para comprobar si la colisión es lateral
    private bool EsColisionLateral(Transform jugadorTransform)
    {
        // Calcula la posición relativa entre el jugador y el enemigo
        Vector2 direccion = jugadorTransform.position - transform.position;

        // Imprime la dirección para depuración
        Debug.Log($"Dirección relativa: {direccion}");

        // Evalúa si es colisión lateral
        float umbral = 0.5f; // Aumenta el umbral si es muy estricto
        bool esLateral = Mathf.Abs(direccion.y) < umbral && Mathf.Abs(direccion.x) > Mathf.Abs(direccion.y);

        // Depuración del resultado
        Debug.Log($"¿Colisión lateral? {esLateral}");

        return esLateral;
    }
}