using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartButton : MonoBehaviour
{
    public Button startButton;

    void OnEnable()
    {
        startButton.onClick.AddListener(startGame);
    }

    void OnDisable()
    {
        startButton.onClick.RemoveListener(startGame);
    }

    private void startGame() {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Level");
    }



}
