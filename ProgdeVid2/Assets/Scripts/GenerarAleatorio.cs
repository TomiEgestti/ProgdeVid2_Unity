using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerarAleatorio : MonoBehaviour
{

    [SerializeField] private GameObject[] objetosprefab;
    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempoespera;

    [SerializeField]
    [Range(0.5f, 5f)]
    private float tiempointervalo;


    void Start()
    {
        InvokeRepeating(nameof(GenerarObjetoAleatorio), tiempoespera, tiempointervalo);
    }

    void GenerarObjetoAleatorio()
    {
        int indexaleatorio = Random.Range(0, objetosprefab.Length);
        GameObject prefabaleatorio = objetosprefab[indexaleatorio];
        Instantiate(prefabaleatorio, transform.position, Quaternion.identity);
    }

}
