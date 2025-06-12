using UnityEngine;

[CreateAssetMenu(fileName = "New Food", menuName = "Inventory/Food")]
public class FoodItem : ScriptableObject
{
    public float hungerRestore;
    public string itemName;
    public Sprite icon;
}
