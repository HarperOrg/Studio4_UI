using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText;
    private int score = 0;

    [SerializeField] private coinUpdate coinUpdate;
    [SerializeField] private InputManager inputManager;
    [SerializeField] private GameObject settingsMenu;

    private bool isSettingsMenuActive;

    public bool IsSettingsMenuActive => isSettingsMenuActive;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject); // Ensures GameManager persists
        }
        else
        {
            Destroy(gameObject); // Prevents duplicate GameManager instances
        }

        inputManager.OnSettingsMenu.AddListener(ToggleSettingsMenu);
        DisableSettingsMenu();
    }

    public void AddScore(int value)
    {
        score += value;
        coinUpdate.UpdateScore(score);
    }

    private void ToggleSettingsMenu()
 {
 if (isSettingsMenuActive) DisableSettingsMenu();
 else EnableSettingsMenu();
 }

 private void EnableSettingsMenu()
 {
 Time.timeScale = 0f;
 settingsMenu.SetActive(true);
 Cursor.lockState = CursorLockMode.None;
 Cursor.visible = true;
 isSettingsMenuActive = true;
 }

    public void DisableSettingsMenu()
 {
 Time.timeScale = 1f;
 settingsMenu.SetActive(false);
 Cursor.lockState = CursorLockMode.Locked;
 Cursor.visible = false;
 isSettingsMenuActive = false;
 }
}