using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    // Start is called before the first frame update

    public Transform player;
    public Text scoreText;
    
    private float startZ;
    private int score = 0;

    private void Start()
    {
        startZ = player.position.z;
        scoreText.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if ((player.position.z - startZ) % 20 == 0 || ((score + 1) * 20) + startZ <= player.position.z) {
            score++;
            scoreText.text = score.ToString();
        }
    }
}
