using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class Vida : MonoBehaviour
{
    [SerializeField] private PerfilJugador PerfilJugador;
    [SerializeField] private UnityEvent<float> OnLivesChanged;

    private Rigidbody2D miRigidbody2D;
    private SpriteRenderer miSpriteRenderer;
    private Animator miAnimator;

    private int vidaActual;  
    private bool isDead = false;
    private bool dañado = false;

    private void Start()
    {
        vidaActual = PerfilJugador.vida;
        OnLivesChanged.Invoke(vidaActual);

        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
    }

    public void ModificarVida(int puntos)
    {
        dañado = true;
        vidaActual += puntos;

        OnLivesChanged.Invoke(vidaActual);

        if (vidaActual <= 0 && !isDead)
        {
            Morir();
        }

        Debug.Log(EstasVivo());
    }

    private bool EstasVivo()
    {
        return vidaActual > 0;
    }

    private void Morir()
    {
        isDead = true;

        transform.rotation = Quaternion.Euler(0f, 0f, 90f);
        miSpriteRenderer.color = Color.red;
        miRigidbody2D.bodyType = RigidbodyType2D.Kinematic;
        miRigidbody2D.velocity = Vector2.zero;
        GetComponent<Mover>().enabled = false;
        GetComponent<Saltar>().enabled = false;

    }

   
    public void ReiniciarVida()
    {
        vidaActual = PerfilJugador.vida;
        OnLivesChanged.Invoke(vidaActual);
        isDead = false;
        dañado = false;

        transform.rotation = Quaternion.identity;
        miRigidbody2D.bodyType = RigidbodyType2D.Dynamic;
        GetComponent<Mover>().enabled = true;
        GetComponent<Saltar>().enabled = true;
    }
}