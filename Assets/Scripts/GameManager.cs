using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool gameEnd = false;

    public void Win()
    {
        if (gameEnd)
        {
            return;
        }

        gameEnd = true;
        Debug.Log("you won!");

        Time.timeScale = 0f; // game freeze
    }

    public void Lose()
    {
        if (gameEnd)
        {
            return;
        }

        gameEnd = true;
        Debug.Log("you lose");

        Time.timeScale = 0f;
    }
}
