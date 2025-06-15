using UnityEngine;

public class TamerTool : MonoBehaviour
{
    public float tameRange = 5f;
    public KeyCode tameKey = KeyCode.T;

    void Update()
    {
        if (Input.GetKeyDown(tameKey))
        {
            TryTameCreature();
        }
    }

    void TryTameCreature()
    {
        Ray ray = new Ray(transform.position, transform.forward);
        if (Physics.Raycast(ray, out RaycastHit hit, tameRange))
        {
            Tameable tameable = hit.collider.GetComponent<Tameable>();
            if (tameable != null)
            {
                tameable.TryToTame();
            }
            else
            {
                Debug.Log("Tidak ada makhluk yang bisa dijinakkan di depan.");
            }
        }
    }
}
