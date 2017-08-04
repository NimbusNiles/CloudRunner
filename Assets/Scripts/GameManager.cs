using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour {

    public float moveSpeed;

    //Clouds
    public float minCloudSize, maxCloudSize;
    public float minCloudGap, maxCloudGap;
    public bool cloudLeft = true;
    public bool noGaps;
    
    private float currentGap, nextCloudGap;
    private float nextCloudSize;
    private CloudSpawner cloudSpawner;

    // Gold
    public float minGoldTime, maxGoldTime;

    private float timeSinceLastGold, nextGoldTime, goldHeight;
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

            if (currentGap >= nextCloudGap || noGaps) {
                SpawnCloud();
            }
        }


        //timeSinceLastGold += Time.deltaTime;
        //if (timeSinceLastGold > nextGoldTime) {
        //    SpawnCoin();
        //}
    }

    private void SpawnCoin() {
        if (cloudLeft) {
            goldHeight = 2f;
        } else {
            goldHeight = 0f;
        }

        goldSpawner.SpawnGold(moveSpeed, Color.yellow, goldHeight);
        nextGoldTime = Random.Range(minGoldTime, maxGoldTime);
        timeSinceLastGold = 0;
    }

    private void SpawnCloud() {
        cloudSpawner.SpawnNextCloud(nextCloudSize, moveSpeed);
        cloudLeft = false;
        currentGap = 0;
        nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
        nextCloudSize = Random.Range(minCloudSize, maxCloudSize);
    }
}
