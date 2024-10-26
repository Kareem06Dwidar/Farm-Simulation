using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public int score = 0; // Tracks the game score
    public Text scoreText; // Assign a UI Text element in the Inspector

    // Method to add points to the score
    public void AddScore(int points)
    {
        score += points;
        UpdateScoreUI();
    }

    // Method to update the score display
    private void UpdateScoreUI()
    {
        if (scoreText != null)
        {
            scoreText.text = "Score: " + score;
        }
    }
}
