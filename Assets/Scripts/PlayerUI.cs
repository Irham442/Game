using UnityEngine;
using UnityEngine.UI;

public class PlayerUI : MonoBehaviour
{
    public PlayerStats playerStats;

    public Slider healthBar;
    public Slider staminaBar;
    public Slider hungerBar;

    void Update()
    {
        if (playerStats != null)
        {
            healthBar.value = playerStats.currentHealth / playerStats.maxHealth;
            staminaBar.value = playerStats.currentStamina / playerStats.maxStamina;
            hungerBar.value = playerStats.hunger / 100f;
        }
        else
        {
            Debug.LogWarning("PlayerStats belum di-assign!");
        }
    }
}
