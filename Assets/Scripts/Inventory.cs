using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public List<FoodItem> foodItems = new List<FoodItem>();
    public PlayerStats playerStats;

    public void AddItem(FoodItem item)
    {
        foodItems.Add(item);
        Debug.Log($"Item {item.itemName} ditambahkan ke inventori.");
    }

    public void UseItem(int index)
    {
        if (index < 0 || index >= foodItems.Count) return;

        FoodItem food = foodItems[index];
        playerStats.hunger = Mathf.Clamp(playerStats.hunger + food.hungerRestore, 0, 100f);
        foodItems.RemoveAt(index);
        Debug.Log($"Makan {food.itemName}, hunger sekarang: {playerStats.hunger}");
    }
}
