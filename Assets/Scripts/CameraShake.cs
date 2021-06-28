using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    private float elapsed = 0.0f;
    private float magnitude = 0.4f;
    private Vector3 originalPos;
    public bool isShaking = false;
    private bool isPaused = false;
    public IEnumerator Shake(float duration) {
        if (originalPos == null) originalPos = transform.position;
        isShaking = true;

        while (elapsed < duration) {
            if (!isPaused)
            {
                float x = Random.Range(-1f, 1f) * Mathf.Pow(magnitude * 2, 2);
                float y = Random.Range(-1f, 1f) * Mathf.Pow(magnitude * 2, 2);

                transform.localPosition = new Vector3(originalPos.x + x, originalPos.y + y, originalPos.z);

                elapsed += Time.deltaTime;
            }

            yield return null;
        }

        elapsed = 0.0f;

        transform.localPosition = originalPos;

        isShaking = false;
    }

    public void setMagnitude(float magnitude) {
        this.magnitude = magnitude;
    }

    void Update()
    {
        if (GameManager.INSTANCE.getGameState("PAUSED") == "TRUE")
        {
            isPaused = true;
        }
        else {
            isPaused = false;
        }
    }
}
