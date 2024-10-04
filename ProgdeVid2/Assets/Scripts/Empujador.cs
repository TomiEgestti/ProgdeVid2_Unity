using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujador : MonoBehaviour
{
    private AudioSource miAudioSource;
    [SerializeField] private AudioClip Empuje;
    public float forceMagnitude = 500f; // La magnitud de la fuerza hacia la derecha

    private void OnEnable()
    {
        miAudioSource = GetComponent<AudioSource>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Verificamos si el objeto que colisiona es el jugador
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el Rigidbody2D del jugador
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
                
            // Verificar si el jugador está colisionando en la parte inferior del sprite
            // Comparar las posiciones en el eje Y
            if (collision.contacts[0].point.x > transform.position.x)
            {
                // Aplicar fuerza hacia la derecha
                Vector2 force = new Vector2(100, 0);
                playerRb.AddForce(force, ForceMode2D.Impulse);
                miAudioSource.PlayOneShot(Empuje);
            } else if (collision.contacts[0].point.y > transform.position.y){
                // Aplicar fuerza hacia arriba
                Vector2 force = new Vector2(0, forceMagnitude);
                playerRb.AddForce(force, ForceMode2D.Impulse);
                miAudioSource.PlayOneShot(Empuje);
            }
        }
    }
}
