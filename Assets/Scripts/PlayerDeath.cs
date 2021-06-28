using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDeath : MonoBehaviour
{
    public Transform ground;
    public PlayerMovement movementScript;

    // Update is called once per frame
    void Update()
    {
        if (
            transform.position.y < ground.position.y
           ) {
            movementScript.enabled = false;
            GameManager.INSTANCE.EndGame();
        }
    }
}
