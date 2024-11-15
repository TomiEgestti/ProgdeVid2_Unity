using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileShooter : MonoBehaviour
{
    public float shootInterval = 0.5f; // Intervalo de disparo
    public ObjectPooler objectPooler; // Referencia al pool de objetos

    private void Start()
    {
        StartCoroutine(ShootProjectile());
    }

    private IEnumerator ShootProjectile()
    {
        while (true)
        {
            yield return new WaitForSeconds(shootInterval);

            GameObject projectile = objectPooler.GetPooledObject();
            if (projectile != null)
            {
                projectile.transform.position = transform.position;
                projectile.transform.rotation = transform.rotation;
                projectile.SetActive(true); // Activa el proyectil
            }
        }
    }
}