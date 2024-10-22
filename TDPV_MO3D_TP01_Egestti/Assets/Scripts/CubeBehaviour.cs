using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeBehaviour : MonoBehaviour
{
    public float rotationSpeed = 100f;

    private int rotationDirection = 0;

    public void SetRotationDirection(int direction)
    {
        rotationDirection = direction;
    }

    public void StopRotation()
    {
        rotationDirection = 0;
    }

    void Update()
    {
        if (rotationDirection != 0)
        {
            transform.Rotate(Vector3.up * rotationSpeed * rotationDirection * Time.deltaTime);
        }
    }
}