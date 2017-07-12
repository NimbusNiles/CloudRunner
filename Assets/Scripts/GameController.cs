using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public float moveSpeed;
    public float minCloudSize, maxCloudSize;
    public float minCloudGap, maxCloudGap;
    public bool cloudLeft = true;
    
    private float currentGap, nextCloudGap;
    private float nextCloudSize;

    private CloudSpawner cloudSpawner;
    //private GroundObstacleSpawner groundObstacleSpawner;

    private void OnEnable() {
        CloudSpawner.OnCloudLeftSpawner += (() => cloudLeft = true);
    }
    
    private void Start() {
        cloudSpawner = FindObjectOfType<CloudSpawner>();
        //groundObstacleSpawner = FindObjectOfType<GroundObstacleSpawner>();

        nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
        nextCloudSize = Random.Range(minCloudSize, maxCloudSize);
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
    }
}
