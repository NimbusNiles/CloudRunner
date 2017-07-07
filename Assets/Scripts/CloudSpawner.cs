using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudSpawner : MonoBehaviour {

    public GameObject cloudPrefab;
    public float cloudSpeed;
    public float minCloudSize, maxCloudSize;
    public float minCloudGap, maxCloudGap;
    
    private bool cloudLeft = true;
    private float currentGap, nextCloudGap;
    private float nextCloudSize;
    private GameObject cloudParent;

    private void Start() {
        cloudParent = GameObject.Find("Clouds");
        if (!cloudParent) {
            cloudParent = new GameObject("Clouds");
        } 
        
        nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
    }

    private void Update() {
        if (cloudLeft) {
            currentGap += cloudSpeed * Time.deltaTime;
        }

        if (currentGap >= nextCloudGap) {
            SpawnNextCloud();
            cloudLeft = false;
            currentGap = 0;
            nextCloudGap = Random.Range(minCloudGap, maxCloudGap);
            nextCloudSize = Random.Range(minCloudSize, maxCloudSize);
        }
    }

    private void OnTriggerExit2D(Collider2D collision) {
        cloudLeft = true;
    }

    void SpawnNextCloud() {
        GameObject cloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        cloud.transform.parent = cloudParent.transform;
        cloud.transform.localPosition += Vector3.right * (nextCloudSize / 2) - Vector3.right * 0.5f;
        cloud.transform.localScale += Vector3.right * nextCloudSize;

        cloud.GetComponent<Rigidbody2D>().velocity = Vector2.left * cloudSpeed;
        cloud.tag = "Cloud";
        
    }
}
