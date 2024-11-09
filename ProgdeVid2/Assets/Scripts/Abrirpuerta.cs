using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Abrirpuerta : MonoBehaviour
{
    private ObjectCollector objectCollector;

    private Rigidbody2D miRigidbody2D;
    private Animator miAnimator;
    private AudioSource miAudioSource;
    private CircleCollider2D coli;
    [SerializeField] private AudioClip Finnivel;

    [SerializeField] private string requiredItem = "Llave azul"; 

    private void OnEnable()
    {
        miRigidbody2D = GetComponent<Rigidbody2D>();
        miAnimator = GetComponent<Animator>();
        miAudioSource = GetComponent<AudioSource>();
        coli = GetComponent<CircleCollider2D>();

        objectCollector = GameObject.FindWithTag("Player").GetComponent<ObjectCollector>();

        miAnimator.SetBool("Abrio?", false);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (objectCollector.HasItem(requiredItem))
            {
                miAnimator.SetBool("Abrio?", true);
                miAudioSource.PlayOneShot(Finnivel);
                Destroy(coli);

                objectCollector.RemoveItem(requiredItem);
            }
        }
    }
}