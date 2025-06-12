using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    public List<FoodItem> inventory = new List<FoodItem>();

    public void AddItem(FoodItem item)
    {
        inventory.Add(item);
        Debug.Log($"Item {item.itemName} ditambahkan ke inventory.");
    }

    public void UseItem(FoodItem item, PlayerStats playerStats)
    {
        if (inventory.Contains(item))
        {
            inventory.Remove(item);
            playerStats.IncreaseHunger(item.hungerRestore);
            Debug.Log($"Menggunakan {item.itemName}, hunger bertambah {item.hungerRestore}");
        }
    }
}
