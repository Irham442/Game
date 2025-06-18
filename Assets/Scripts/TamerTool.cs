using UnityEngine;

public class TamerTool : MonoBehaviour
{
    public float tameRange = 10f; // Naikkan sedikit untuk tes
    public KeyCode tameKey = KeyCode.T;
    
    // Variabel ini SANGAT PENTING
    public Camera playerCamera; 
    public LayerMask tameableLayers;

    void Update()
    {
        if (Input.GetKeyDown(tameKey))
        {
            TryTameCreature();
        }
    }

    void TryTameCreature()
    {
        // --- INI BAGIAN PALING PENTING YANG MEMPERBAIKI MASALAH ANDA ---
        // Kita tidak lagi menggunakan transform.forward, tapi menembak dari tengah layar.
        Ray ray = playerCamera.ScreenPointToRay(new Vector3(Screen.width / 2f, Screen.height / 2f));
        
        // Gunakan Debug.DrawRay untuk melihat sinarnya di Scene View saat testing
        Debug.DrawRay(ray.origin, ray.direction * tameRange, Color.cyan, 2f);

        if (Physics.Raycast(ray, out RaycastHit hit, tameRange, tameableLayers))
        {
            // Cek apakah yang kena adalah objek dengan script Tameable
            Tameable tameable = hit.collider.GetComponent<Tameable>();
            if (tameable != null)
            {
                // Panggil fungsi taming
                tameable.TryToTame(this.transform);
            }
        }
        else
        {
            // Debug.Log("Tidak ada target di depan."); // Bisa di-uncomment untuk tes
        }
    }
}
