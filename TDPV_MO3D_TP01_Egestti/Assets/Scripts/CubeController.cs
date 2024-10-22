using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeController : MonoBehaviour
{
    private CubeBehaviour cubeBehaviour;

    void Start()
    {
        cubeBehaviour = GetComponent<CubeBehaviour>();
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.RightArrow))
        {
            cubeBehaviour.SetRotationDirection(1);  // Rotar en sentido horario
        }
        else if (Input.GetKey(KeyCode.LeftArrow))
        {
            cubeBehaviour.SetRotationDirection(-1); // Rotar en sentido antihorario
        }
        else if (Input.GetKey(KeyCode.Space))
        {
            cubeBehaviour.StopRotation();  // Detener la rotación
        }
    }
}