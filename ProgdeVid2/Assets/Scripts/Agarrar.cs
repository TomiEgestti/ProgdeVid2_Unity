using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public Transform holdPoint;            // El punto donde se "sostendr�" el objeto
    private GameObject pickedUpObject;     // Objeto que est� recogido

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))   // Detectar si el jugador presiona 'E'
        {
            if (pickedUpObject == null)    // Si no tiene un objeto recogido
            {
                TryPickupObject();
            }
            else
            {
                DropObject();              // Si ya tiene un objeto, lo suelta
            }
        }
    }

    // Intentar recoger el objeto
    void TryPickupObject()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, 1f);  // Busca objetos cercanos

        foreach (var collider in colliders)
        {
            if (collider.CompareTag("Pickup"))  // Si colisiona con un objeto con tag 'Pickup'
            {
                pickedUpObject = collider.gameObject;
                pickedUpObject.layer = LayerMask.NameToLayer("Sosteniendo");// Asignar el objeto
                pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = true;  // Desactivar la f�sica
                pickedUpObject.transform.position = holdPoint.position;  // Colocar el objeto en el punto de sost�n
                pickedUpObject.transform.parent = holdPoint;  // Hacerlo hijo del punto de sost�n
                break;
            }
        }
    }

    // Soltar el objeto
    void DropObject()
    {
        pickedUpObject.GetComponent<Rigidbody2D>().isKinematic = false;  // Reactivar f�sica
        pickedUpObject.transform.parent = null;  // Quitar del holdPoint
        pickedUpObject = null;  // Limpiar la referencia
    }
}
