using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vida : MonoBehaviour
{
    [Header("Configuracion")]
    [SerializeField] private float vida = 5f;

    private Rigidbody2D miRigidbody2D;
    private bool isDead = false;  // Variable para verificar si ya está "muerto"

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
    }

    public void ModificarVida(float puntos)
    {
        vida += puntos;
        if (vida <= 0 && !isDead)  // Verificar que la vida es <= 0 y que no está "muerto"
        {
            Morir();  // Llamar a la función que maneja la "muerte"
        }
        Debug.Log(EstasVivo());
    }

    private bool EstasVivo()
    {
        return vida > 0;
    }

    private void Morir()
    {
        isDead = true;

        // Rotar el jugador para que parezca "tirado"
        transform.rotation = Quaternion.Euler(0f, 0f, 90f);  // Rotar 90 grados en el eje Z

        // Desactivar el Rigidbody para que no pueda moverse
        miRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        miRigidbody2D.velocity = Vector2.zero;
        GetComponent<Mover>().enabled = false;
        GetComponent<Saltar>().enabled = false;
    }

    }