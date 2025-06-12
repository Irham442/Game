using UnityEngine;

public class Tameable : MonoBehaviour
{
    public string creatureName = "Unnamed";
    public bool isTamed = false;
    public float tameChance = 0.5f; // 50%

    public bool TryToTame()
    {
        if (isTamed) return true;

        float roll = Random.Range(0f, 1f);
        if (roll <= tameChance)
        {
            isTamed = true;
            Debug.Log($"{creatureName} berhasil dijinakkan!");
            return true;
        }
        else
        {
            Debug.Log($"{creatureName} gagal dijinakkan.");
            return false;
        }
    }
}
