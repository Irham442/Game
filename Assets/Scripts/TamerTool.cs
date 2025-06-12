using UnityEngine;

public class TamerTool : MonoBehaviour
{
    public float tameRange = 5f;
    public KeyCode tameKey = KeyCode.T;
    public Camera playerCamera;

    void Start()
    {
        if (playerCamera == null)
        {
            playerCamera = Camera.main;
        }
    }

    void Update()
    {
        if (Input.GetKeyDown(tameKey))
        {
            TryTameCreature();
        }
    }

    void TryTameCreature()
    {
        Ray ray = playerCamera.ViewportPointToRay(new Vector3(0.5f, 0.5f, 0f));
        if (Physics.Raycast(ray, out RaycastHit hit, tameRange))
        {
            Tameable tameable = hit.collider.GetComponent<Tameable>();
            if (tameable != null)
            {
                bool success = tameable.TryToTame();
                if (success)
                {
                    Debug.Log("Tame success!");
                }
            }
            else
            {
                Debug.Log("Tidak ada makhluk Tameable.");
            }
        }
        else
        {
            Debug.Log("Ray tidak mengenai apapun.");
        }
    }
}
