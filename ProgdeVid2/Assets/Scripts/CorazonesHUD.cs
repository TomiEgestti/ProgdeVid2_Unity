using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class VidaHUD : MonoBehaviour
{
    [SerializeField] private Image[] corazones; 
    [SerializeField] private Sprite corazonLleno; 
    [SerializeField] private Sprite corazonVacio; 

    public void ActualizarCorazones(float vidaActual)
    {
        for (int i = 0; i < corazones.Length; i++)
        {
            if (i < vidaActual)
            {
                corazones[i].sprite = corazonLleno; 
            }
            else
            {
                corazones[i].sprite = corazonVacio; 
            }
        }
    }
}