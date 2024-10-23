using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    // Diccionario para almacenar el inventario del jugador
    private Dictionary<string, int> inventory = new Dictionary<string, int>();

    // Método para recoger objetos
    public void CollectItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            inventory[itemName] = 1;
        }
    }

    // Método para verificar si el jugador tiene un objeto específico en su inventario
    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

    // Método para eliminar un objeto del inventario
    public void RemoveItem(string itemName)
    {
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]--;

            if (inventory[itemName] <= 0)
            {
                inventory.Remove(itemName);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D other) 
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (other.CompareTag("Pickup"))
            {
                CollectItem(other.gameObject.name);
                Destroy(other.gameObject);
            }
        }
    }
}