using UnityEngine;
using TMPro;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance; // Singleton instance
    public TextMeshProUGUI scoreText;
    private int score = 0;

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
    }

    public void AddScore(int value)
    {
        score += value;
        scoreText.text = "SCORE: " + score;
    }
}