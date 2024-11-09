using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Empujador : MonoBehaviour
{
    private AudioSource miAudioSource;
    [SerializeField] private AudioClip Empuje;
    public float forceMagnitude = 500f;

    private void OnEnable()
    {
        miAudioSource = GetComponent<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Rigidbody2D playerRb = collision.gameObject.GetComponent<Rigidbody2D>();

            Vector2 contactPoint = collision.contacts[0].point;
            Vector2 center = transform.position;

            if (contactPoint.x > center.x)
            {
                Vector2 force = new Vector2(forceMagnitude, 0);
                playerRb.AddForce(force, ForceMode2D.Impulse);
            }
            else
            {
                Vector2 force = new Vector2(0, forceMagnitude);
                playerRb.AddForce(force, ForceMode2D.Impulse);
            }

            miAudioSource.PlayOneShot(Empuje);
        }
    }
}