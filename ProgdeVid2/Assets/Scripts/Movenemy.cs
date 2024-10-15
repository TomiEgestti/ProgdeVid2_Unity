using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movenemy : MonoBehaviour
{
    public float moveSpeed = 5f;           // Velocidad del enemigo
    private Rigidbody2D rb;                // Referencia al Rigidbody2D
    public bool movingRight = true;        // Direcci�n inicial del enemigo

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();  // Obtener el Rigidbody2D del enemigo
    }

    void Update()
    {
        // Mover al enemigo hacia la derecha o izquierda
        if (movingRight)
        {
            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);  // Mover hacia la derecha
        }
        else
        {
            rb.velocity = new Vector2(-moveSpeed, rb.velocity.y); // Mover hacia la izquierda
        }
    }

    // Detectar colisiones con los l�mites
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Cambiar direcci�n al colisionar con los l�mites
        if (movingRight)
        {
            movingRight = false;  // Cambiar direcci�n a izquierda
        }
        else if (!movingRight)
        {
            movingRight = true;   // Cambiar direcci�n a derecha
        }
    }
}
