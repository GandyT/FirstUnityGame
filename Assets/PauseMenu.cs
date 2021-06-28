using UnityEngine;

public class PauseMenu : MonoBehaviour
{
    public GameObject pauseMenu;

    private bool gamePaused = false;
    private void Update()
    {
        bool isPressed = Input.GetKeyDown(KeyCode.Escape);

        if (isPressed) {
            gamePaused = !gamePaused;

            if (gamePaused)
            {
                PauseGame();
            } else
            {
                ResumeGame();
            }
        };

    }

    public void PauseGame()
    {
        Time.timeScale = 0f;
        GameManager.INSTANCE.setGameState("PAUSED", "TRUE");
        pauseMenu.SetActive(true);
    }

    public void ResumeGame() {
        Time.timeScale = 1f;
        GameManager.INSTANCE.setGameState("PAUSED", "FALSE");
        pauseMenu.SetActive(false);
    }

    public void QuitGame ()
    {
        Debug.Log("Qutting Game");
        Application.Quit();
    }
}
