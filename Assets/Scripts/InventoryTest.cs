using UnityEngine;

public class InventoryTest : MonoBehaviour
{
    public InventoryManager inventoryManager;
    public PlayerStats playerStats;
    public FoodItem testFoodItem;  // drag Apel ke sini di Inspector

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            inventoryManager.UseItem(testFoodItem, playerStats);
        }
    }
}
