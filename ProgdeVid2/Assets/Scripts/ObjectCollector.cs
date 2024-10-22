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
        // Si el objeto ya está en el inventario, aumentar la cantidad
        if (inventory.ContainsKey(itemName))
        {
            inventory[itemName]++;
        }
        else
        {
            // Si el objeto no está en el inventario, añadirlo con cantidad 1
            inventory[itemName] = 1;
        }

        // Mensaje para mostrar el objeto recogido y la cantidad
        Debug.Log("Collected: " + itemName + ". You now have " + inventory[itemName] + " of this item.");
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
            // Reducimos la cantidad del objeto
            inventory[itemName]--;

            // Si la cantidad llega a 0, lo eliminamos del inventario
            if (inventory[itemName] <= 0)
            {
                inventory.Remove(itemName);
            }

            Debug.Log(itemName + " has been removed from your inventory.");
        }
        else
        {
            Debug.Log("You don't have " + itemName + " in your inventory to remove.");
        }
    }

    // Este método simula la interacción cuando el jugador presiona "E"
    void OnTriggerStay(Collider other)
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            // Verifica si el objeto tiene la etiqueta "Collectible"
            if (other.CompareTag("Pickup"))
            {
                // Recoger el objeto
                CollectItem(other.gameObject.name);
                Debug.Log("You don't have "  + " in your inventory to remove.");

                // Destruir el objeto recogido de la escena
                Destroy(other.gameObject);
            }
        }
    }
}
