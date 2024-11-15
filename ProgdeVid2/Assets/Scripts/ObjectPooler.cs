using System.Collections.Generic;
using UnityEngine;

public class ObjectPooler : MonoBehaviour
{
    public GameObject pooledObject; // El objeto que se va a crear en el pool
    public int poolSize; // Tamaño inicial del pool

    private List<GameObject> objectPool;

    private void Start()
    {
        objectPool = new List<GameObject>();
        for (int i = 0; i < poolSize; i++)
        {
            GameObject obj = Instantiate(pooledObject);
            obj.SetActive(false); // Desactiva el objeto inicialmente
            objectPool.Add(obj);
        }
    }

    // Devuelve un objeto desactivado del pool para su uso
    public GameObject GetPooledObject()
    {
        foreach (GameObject obj in objectPool)
        {
            if (!obj.activeInHierarchy) // Encuentra un objeto que esté desactivado
            {
                return obj; // Devuelve el objeto
            }
        }

        // Si todos los objetos están activos, se puede opcionalmente crear uno nuevo y añadirlo al pool
        GameObject newObj = Instantiate(pooledObject);
        newObj.SetActive(false);
        objectPool.Add(newObj);
        return newObj;
    }

    // Desactiva el objeto para que pueda ser reutilizado en el pool
    public void DesactivarObjeto(GameObject objeto)
    {
        objeto.SetActive(false);
    }
}