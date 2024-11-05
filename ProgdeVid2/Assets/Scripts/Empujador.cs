using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujador : MonoBehaviour
{
    private AudioSource miAudioSource;
    [SerializeField] private AudioClip Empuje;
    public float forceMagnitude = 500f; // Magnitud de la fuerza

    private void OnEnable()
    {
        miAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            // Obtener el Rigidbody2D del jugador
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();
            if (playerRb == null) return;

            // Obtener el punto de colisión
            Vector2 collisionPoint = collision.contacts[0].point;

            // Verificar si el jugador colisiona a la derecha del objeto
            if (collisionPoint.x > transform.position.x)
            {
                // Aplicar fuerza hacia la derecha
                Vector2 force = new Vector2(forceMagnitude, 0);
                playerRb.AddForce(force, ForceMode2D.Impulse);
                miAudioSource.PlayOneShot(Empuje);
                Debug.Log("Empuje hacia la derecha");
            }
            // Verificar si el jugador colisiona en la parte inferior del objeto
            else if (collisionPoint.y < transform.position.y)
            {
                // Aplicar fuerza hacia arriba
                Vector2 force = new Vector2(0, forceMagnitude);
                playerRb.AddForce(force, ForceMode2D.Impulse);
                miAudioSource.PlayOneShot(Empuje);
                Debug.Log("Empuje hacia arriba");
            }
        }
    }
}