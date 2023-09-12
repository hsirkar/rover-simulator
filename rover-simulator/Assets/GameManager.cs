using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public Transform player;
    public GameObject enemy;

    public float scoreMultiplier = 100;
    public int score = 0;

    public Vector3 spawnOffset;

    public float distanceThresholdMin = 50;
    public float distanceThresholdMax = 100;

    private float distanceThreshold;
    private float lastSpawnZ = 0;

    void Start()
    {
        distanceThreshold = Random.Range(distanceThresholdMin, distanceThresholdMax);
    }

    // Update is called once per frame
    void Update()
    {
        score = Mathf.RoundToInt(player.position.z * scoreMultiplier);

        if(player.transform.position.z + spawnOffset.z > lastSpawnZ + distanceThreshold)
        {
            GameObject instance = (GameObject) Instantiate(enemy, new Vector3(Random.Range(-20, 20), 1.25f, player.transform.position.z + spawnOffset.z), Quaternion.identity);

            lastSpawnZ = instance.transform.position.z;
            distanceThreshold = Random.Range(distanceThresholdMin, distanceThresholdMax);
        }

        if(Input.GetKeyDown("space")){
            if(Time.timeScale == 0.0f) {
                Time.timeScale = 1.0f;
            } else {
                Time.timeScale = 0.0f;
            }
        }

        if(Input.GetKey("r")) {
            Time.timeScale = 1.0f;
            SceneManager.LoadScene("Level");
        }
    }
}
