using UnityEngine;

public class PlayerSettings : MonoBehaviour
{
    public GameObject settingsCanvas;
    public GameObject gameplayCanvas;

    public MonoBehaviour playerMovementScript; // Drag script player movement-mu di Inspector

    private bool isSettingsOpen = false;

    void Start()
    {
        settingsCanvas.SetActive(false);
        SetCursorState(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            isSettingsOpen = !isSettingsOpen;

            settingsCanvas.SetActive(isSettingsOpen);
            gameplayCanvas.SetActive(!isSettingsOpen);

            SetCursorState(isSettingsOpen);
            if (playerMovementScript != null)
            {
                playerMovementScript.enabled = !isSettingsOpen;
            }
        }
    }

    void SetCursorState(bool unlocked)
    {
        Cursor.lockState = unlocked ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = unlocked;
    }
}
