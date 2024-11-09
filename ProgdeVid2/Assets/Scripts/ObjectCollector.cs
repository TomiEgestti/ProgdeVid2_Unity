using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectCollector : MonoBehaviour
{
    private Dictionary<string, int> inventory = new Dictionary<string, int>();
    private bool isInTrigger = false; 
    private string currentItem = ""; 

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

    public bool HasItem(string itemName)
    {
        return inventory.ContainsKey(itemName);
    }

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
        if (other.CompareTag("Pickup"))
        {
            isInTrigger = true; 
            currentItem = other.gameObject.name; 
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Pickup"))
        {
            isInTrigger = false; 
            currentItem = ""; 
        }
    }

    void Update()
    {
        if (isInTrigger && Input.GetKeyDown(KeyCode.E))
        {
            CollectItem(currentItem); 
            GameObject.Find(currentItem)?.SetActive(false); 
        }
    }
}