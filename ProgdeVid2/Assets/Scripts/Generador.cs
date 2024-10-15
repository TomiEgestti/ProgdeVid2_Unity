using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Generador : MonoBehaviour
{
    [SerializeField] private GameObject objetoPrefab;
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoespera;
    void Start()
    {
        Invoke("GenerarObjeto", tiempoespera);
    }

void GenerarObjeto()
    {
        Instantiate(objetoPrefab, transform.position, Quaternion.identity);
    }
}
