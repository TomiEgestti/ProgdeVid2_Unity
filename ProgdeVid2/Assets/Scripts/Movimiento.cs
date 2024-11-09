using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField]
    private PerfilJugador perfilJugador;
    public PerfilJugador PerfilJugador { get => perfilJugador; }

    private float moverHorizontal;
    private Vector2 direccion;

    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private SpriteRenderer miSprite;

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miSprite = GetComponent<SpriteRenderer>();
    }
    private void Update()
    {
        moverHorizontal = Input.GetAxis("Horizontal");
        miAnimator.SetBool("EnAire", miRigidbody2D.velocity.y != 0f);
        direccion = new Vector2(moverHorizontal, 0f);

        int velocidadX = (int)miRigidbody2D.velocity.x;
        miSprite.flipX = moverHorizontal < 0f;
        miAnimator.SetInteger("vel", Mathf.Abs(velocidadX));
    }

    private void FixedUpdate()
    {
        Vector2 newVelocity = new Vector2(moverHorizontal * PerfilJugador.velocidad, miRigidbody2D.velocity.y);
        miRigidbody2D.velocity = newVelocity;
    }
}