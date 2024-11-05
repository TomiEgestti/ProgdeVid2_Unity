using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    // Variables de uso interno en el script
    private float moverHorizontal;
    private Vector2 direccion;

    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;

    // Código ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
    }

    // Código ejecutado en cada frame del juego (Intervalo variable)
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        miAnimator.SetBool("EnAire", miRigidbody2D.velocity.y != 0f);
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = moverHorizontal < 0f;
        miAnimator.SetInteger("vel", Mathf.Abs(velocidadX));
    }

    // Código ejecutado en cada paso de física (Intervalo fijo)
    private void FixedUpdate()
    {
        // Solo aplicamos velocidad horizontal sin afectar la velocidad vertical existente
        Vector2 newVelocity = new Vector2(moverHorizontal * PerfilJugador.velocidad, miRigidbody2D.velocity.y);
        miRigidbody2D.velocity = newVelocity;
    }
}