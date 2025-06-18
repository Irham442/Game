using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public float maxHealth = 100f;
    public float currentHealth;
    public bool isTamed = false;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float amount)
    {
        if (isTamed) return; // Tidak menerima damage kalau sudah dijinakkan

        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void Tame()
    {
        isTamed = true;
        Debug.Log("Enemy telah dijinakkan.");
    }

    void Die()
    {
        Debug.Log("Enemy mati.");
        Destroy(gameObject);
    }
}
