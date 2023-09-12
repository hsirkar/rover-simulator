using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CanvasController : MonoBehaviour
{
    public GameManager gameManager;
    public PlayerController player;
    public Image flashImage;

    public Text score;
    public Text numEnemies;

    Coroutine currentFlashRoutine = null;

    // Update is called once per frame
    void Update()
    {
        score.text = "Score: " + gameManager.score;
        numEnemies.text = "Number of enemies hit: " + player.numEnemiesHit;
    }

    public void StartFlash(float time, float maxAlpha) 
    {
        flashImage.color = new Color(1, 0, 0);
        maxAlpha = Mathf.Clamp(maxAlpha, 0.0f, 1.0f);

        if(currentFlashRoutine != null)
            StopCoroutine(currentFlashRoutine);
        
        currentFlashRoutine = StartCoroutine(Flash(time, maxAlpha));
    }

    IEnumerator Flash(float time, float maxAlpha)
    {
        // Flash in
        float flashInTime = time/2;
        for(float t = 0; t <= flashInTime; t += Time.deltaTime)
        {
            Color temp = flashImage.color;
            temp.a = Mathf.Lerp(0, maxAlpha, t / flashInTime);
            flashImage.color = temp;

            // Wait until next frame
            yield return null;
        }

        // Flash out
        for(float t = 0; t <= flashInTime; t += Time.deltaTime)
        {
            Color temp = flashImage.color;
            temp.a = Mathf.Lerp(maxAlpha, 0, t / flashInTime);
            flashImage.color = temp;

            // Wait until next frame
            yield return null;
        }

        flashImage.color = new Color32(1, 0, 0, 0);
    }
}
