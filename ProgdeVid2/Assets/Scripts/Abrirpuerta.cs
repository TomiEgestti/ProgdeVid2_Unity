using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrirpuerta : MonoBehaviour
{
    // Variable para referenciar otro componente del objeto
    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private AudioSource miAudioSource;
    private CircleCollider2D coli;
    [SerializeField] private AudioClip Finnivel;

    // Codigo ejecutado cuando el objeto se activa en el nivel
    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miAudioSource = GetComponent<AudioSource>();
        coli = GetComponent<CircleCollider2D>();
        // Inicializar el estado del booleano en false para que inicie cerrado
        miAnimator.SetBool("Abrio?", false);
    }


    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Llave")
        {
            miAnimator.SetBool("Abrio?", true);
            miAudioSource.PlayOneShot(Finnivel);
            Destroy(other.gameObject);
            Destroy(coli);
            Debug.Log("GANASTE");
        }
    }
}