using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProyectilRecto : MonoBehaviour
{
    [Header("Ajustes del Proyectil")]
    public float velocidad = 5f; // Velocidad del proyectil
    public Vector2 direccion = Vector2.left; // Direcci�n del movimiento (izquierda por defecto)
    public float tiempoDeVida = 3f; // Tiempo en segundos antes de que el proyectil se desactive

    private float tiempoTranscurrido = 0f; // Controla el tiempo desde que el proyectil fue creado
    private ObjectPooler objectPooler; // Referencia al pool de objetos

    private void OnEnable()
    {
        tiempoTranscurrido = 0f;
    }

    void Start()
    {
        objectPooler = FindObjectOfType<ObjectPooler>();
    }

    void Update()
    {
        // Mover el proyectil en la direcci�n indicada
        transform.Translate(direccion * velocidad * Time.deltaTime);

        // Contar el tiempo y desactivar el proyectil si ha pasado el tiempo de vida
        tiempoTranscurrido += Time.deltaTime;
        if (tiempoTranscurrido >= tiempoDeVida)
        {
            DesactivarProyectil();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        // Verificar si colisiona con el jugador o la pared
        if (collision.CompareTag("Player") || collision.CompareTag("Pared"))
        {
            DesactivarProyectil();
        }
    }

    // Desactiva el proyectil en lugar de destruirlo
    private void DesactivarProyectil()
    {
        gameObject.SetActive(false);
    }
}