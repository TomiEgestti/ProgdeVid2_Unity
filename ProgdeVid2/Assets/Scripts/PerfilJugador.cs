using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NuevoPerfilJugador", menuName = "SO/Perfil Jugador")]
public class PerfilJugador : ScriptableObject
{
    [Header("Movimiento")]
    [SerializeField] public float velocidad = 5f;
    [SerializeField] public float fuerzaSalto = 5f;

    [Header("Atributos")]
    [SerializeField] public int vida = 3;

    [Header("Audio y SFX")]
    [SerializeField] public AudioClip SaltoSFX;
}
