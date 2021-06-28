using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager INSTANCE = null;
    public float endDelay = 1f;

    private Dictionary<string, string> GameState = new Dictionary<string, string>();

    bool hasEnd = false;

    private void Awake()
    {
        if (INSTANCE == null)
        {
            INSTANCE = this;
            DontDestroyOnLoad(INSTANCE);
        } else if (INSTANCE != this)
        {
            // Destroy Duplicate GameManagers
            Destroy(gameObject);
        }

        INSTANCE.initKeys();
    }

    public void EndGame() {
        if (hasEnd) return;
        hasEnd = true;
        Debug.Log("Game Over");
        Debug.Log(this.GetInstanceID());
        Invoke("Restart", endDelay);
    }

    void Restart() {
        hasEnd = false;
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    private void initKeys ()
    {
        this.setGameState("PAUSED", "FALSE");
    }

    public void setGameState (string stateName, string stateValue)
    {
        GameState[stateName.ToUpper()] = stateValue.ToUpper();
    }
    public string getGameState(string stateName) {
        return GameState[stateName.ToUpper()];
    }
}
