using UnityEngine;
using TMPro;

public class PlayerSettingsUI : MonoBehaviour
{
    public TMP_InputField nameInput;
    public GameObject settingsCanvas;
    public GameObject gameplayCanvas;

    private const string PLAYER_NAME_KEY = "PlayerName";

    void Start()
    {
        // Coba load nama sebelumnya
        if (PlayerPrefs.HasKey(PLAYER_NAME_KEY))
        {
            string savedName = PlayerPrefs.GetString(PLAYER_NAME_KEY);
            nameInput.text = savedName;
        }
    }

    public void SaveName()
    {
        string inputName = nameInput.text;

        if (!string.IsNullOrEmpty(inputName))
        {
            PlayerPrefs.SetString(PLAYER_NAME_KEY, inputName);
            PlayerPrefs.Save();
            Debug.Log("Nama disimpan: " + inputName);

            // Tutup panel dan kembali ke UI gameplay
            settingsCanvas.SetActive(false);
            gameplayCanvas.SetActive(true);
        }
        else
        {
            Debug.LogWarning("Input nama kosong!");
        }
    }
}
