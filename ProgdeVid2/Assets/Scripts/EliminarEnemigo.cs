using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EliminarEnemigo : MonoBehaviour
{
    [Header("Ajustes de Eliminación")]
    [SerializeField] private float alturaMinimaImpacto = 0.5f; 

    private Rigidbody2D rbJugador;

    private void Start()
    {
        rbJugador = GetComponent<Rigidbody2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verifica si el objeto colisionado es un enemigo
        if (collision.gameObject.CompareTag("Enemy"))
        {
            // Obtiene la posición relativa entre el jugador y el enemigo
            Vector2 posicionJugador = transform.position;
            Vector2 posicionEnemigo = collision.transform.position;

            if (posicionJugador.y - posicionEnemigo.y > alturaMinimaImpacto)
            {
                // Desactiva el enemigo
                Destroy(collision.gameObject);

                ReboteJugador();
            }
        }
    }

    private void ReboteJugador()
    {
        if (rbJugador != null)
        {
            rbJugador.velocity = new Vector2(rbJugador.velocity.x, 18f); 
        }
    }
}
