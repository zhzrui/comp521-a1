using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool gameEnd = false;
    [SerializeField] private GameObject gameEndPanel;
    [SerializeField] private TMP_Text resultText;

    private void Start()
    {
        gameEndPanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Win()
    {
        if (gameEnd)
        {
            return;
        }

        gameEnd = true;
        //Debug.Log("you won!");

        EndGame("You win!");
    }

    public void Lose()
    {
        if (gameEnd)
        {
            return;
        }

        gameEnd = true;
        //Debug.Log("you lose");

        EndGame("You lose!");
    }

    private void EndGame(string message)
    {
        gameEndPanel.SetActive(true);
        resultText.text = message;

        // ensuring cursor is visible
        Cursor.visible = true;

        Time.timeScale = 0f; // stop game
    }

    public void RestartGame()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
