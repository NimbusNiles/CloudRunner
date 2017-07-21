using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float moveSpeed;

    //Clouds
    public float minCloudSize, maxCloudSize;
    public float minCloudGap, maxCloudGap;
    public bool cloudLeft = true;
    
    private float currentGap, nextCloudGap;
    private float nextCloudSize;
    private CloudSpawner cloudSpawner;

    // Gold
    public float minGoldTime, maxGoldTime;

    private float timeSinceLastGold, nextGoldTime;
    private GoldSpawner goldSpawner;
    
    //private GroundObstacleSpawner groundObstacleSpawner;

    private void OnEnable() {
        CloudSpawner.OnCloudLeftSpawner += (() => cloudLeft = true);
    }
    
    private void Start() {
        cloudSpawner = FindObjectOfType<CloudSpawner>();
        goldSpawner = FindObjectOfType<GoldSpawner>();
        //groundObstacleSpawner = FindObjectOfType<GroundObstacleSpawner>();

        nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
        nextCloudSize = Random.Range(minCloudSize, maxCloudSize);
        nextGoldTime = Random.Range(minGoldTime, maxGoldTime);
    }

    private void Update() {
        if (cloudLeft) {
            currentGap += moveSpeed * Time.deltaTime;
        }

        if (currentGap >= nextCloudGap) {
            cloudSpawner.SpawnNextCloud(nextCloudSize, moveSpeed);
            cloudLeft = false;
            currentGap = 0;
            nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
            nextCloudSize = Random.Range(minCloudSize, maxCloudSize);
        }

        timeSinceLastGold += Time.deltaTime;
        if (timeSinceLastGold > nextGoldTime) {
            goldSpawner.SpawnGold(moveSpeed,Color.yellow);
            nextGoldTime = Random.Range(minGoldTime, maxGoldTime);
            timeSinceLastGold = 0;
        }
    }


}
