using UnityEngine;

public class PlayerStats : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;

    public float maxStamina = 100f;
    public float currentStamina;
    public float staminaRegenRate = 5f;

    public float hunger = 100f;
    public float hungerDecreaseRate = 1f;

    public bool isSprinting = false; // tambahkan ini di atas


    void Start()
    {
        currentHealth = maxHealth;
        currentStamina = maxStamina;
    }

    void Update()
    {
        if (!isSprinting)
        {
            RegenerateStamina(); // hanya regen saat tidak sprint
        }

        DecreaseHunger(); // tetap turunkan hunger
    }


    void RegenerateStamina()
    {
        currentStamina += staminaRegenRate * Time.deltaTime;
        currentStamina = Mathf.Clamp(currentStamina, 0, maxStamina);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        Debug.Log("Player mati!");
        // Tambah respawn atau game over
    }

    public bool UseStamina(float amount)
    {
        if (currentStamina >= amount)
        {
            currentStamina -= amount;
            return true;
        }
        return false;
    }

    public void IncreaseHunger(float amount)
    {
        hunger = Mathf.Clamp(hunger + amount, 0f, 100f);
    }

    void DecreaseHunger()
    {
        hunger -= hungerDecreaseRate * Time.deltaTime;
        hunger = Mathf.Clamp(hunger, 0, 100f);

        if (hunger <= 0)
        {
            TakeDamage(5f * Time.deltaTime); // Kehabisan makanan = HP berkurang
        }
    }
}
