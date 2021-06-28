using UnityEngine;

public class DoNotDestroy : MonoBehaviour
{
    public AudioSource backgroundTrack;
    private bool isPaused = false;
    void Start()
    {

        if (GameObject.FindGameObjectsWithTag("BackgroundProcess").Length <= 1)
        {
            Debug.Log("TRACK PLAYING");
            backgroundTrack.Play();
        }
        else {
            Destroy(transform.gameObject);
        }

        DontDestroyOnLoad(transform.gameObject);
    }

    void Update()
    {
        if (GameManager.INSTANCE.getGameState("PAUSED") == "TRUE" && !isPaused)
        {
            backgroundTrack.Pause();
            isPaused = true;
        } else if (GameManager.INSTANCE.getGameState("PAUSED") == "FALSE" && isPaused)
        {
            backgroundTrack.Play();
            isPaused = false;
        }
    }
}
