using UnityEngine;
using UnityEngine.AI;

[RequireComponent(typeof(NavMeshAgent))]
public class Tameable : MonoBehaviour
{
    // --- DEKLARASI YANG KEMUNGKINAN HILANG ADA DI SINI ---
    [Header("Creature Info")]
    public string creatureName = "Unnamed";
    public float tameChance = 0.5f; // 50% chance

    [Header("State & Effects")]
    public bool isTamed = false;
    public GameObject tameSuccessVFX;
    
    // Variabel privat untuk logika internal
    private NavMeshAgent agent;
    private Transform playerTarget;
    // -----------------------------------------------------------

    void Awake()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.enabled = false;
    }

    void Update()
    {
        // Baris ini memanggil isTamed, pastikan sudah dideklarasikan di atas
        if (isTamed && playerTarget != null)
        {
            agent.SetDestination(playerTarget.position);
        }
    }

    public bool TryToTame(Transform tamerTransform)
    {
        if (isTamed) return true; // Cek isTamed, pastikan sudah dideklarasikan

        // --- DEKLARASI 'roll' YANG HILANG ADA DI SINI ---
        float roll = Random.Range(0f, 1f);

        // Baris ini menggunakan 'roll' dan 'tameChance'
        if (roll <= tameChance)
        {
            // --- JIKA BERHASIL (Mengembalikan nilai TRUE) ---
            isTamed = true; // Menggunakan isTamed
            playerTarget = tamerTransform;
            agent.enabled = true;

            if (tameSuccessVFX != null)
            {
                Instantiate(tameSuccessVFX, transform.position, Quaternion.identity);
            }
            
            Debug.Log($"{creatureName} berhasil dijinakkan!");
            return true; // Wajib ada return di path ini
        }
        else
        {
            // --- JIKA GAGAL (Mengembalikan nilai FALSE) ---
            // Blok ELSE ini penting untuk mengatasi error CS0161
            Debug.Log($"{creatureName} gagal dijinakkan.");
            return false; // Wajib ada return di path ini juga
        }
    }
}
