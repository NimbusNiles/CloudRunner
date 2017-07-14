using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class CloudSpawner : MonoBehaviour {

    public GameObject cloudPrefab;
    public static event Action OnCloudLeftSpawner;

    private GameObject cloudParent;

    private void OnDrawGizmos() {
        Gizmos.color = Color.green;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void Start() {
        cloudParent = GameObject.Find("Clouds");
        if (!cloudParent) {
            cloudParent = new GameObject("Clouds");
        } 
    }

    private void OnTriggerExit2D(Collider2D collision) {
        OnCloudLeftSpawner();
    }

    public void SpawnNextCloud(float cloudSize, float cloudSpeed) {
        GameObject cloud = Instantiate(cloudPrefab, transform.position, Quaternion.identity);

        cloud.transform.parent = cloudParent.transform;
        cloud.transform.localPosition += Vector3.right * (cloudSize / 2) - Vector3.right * 0.5f;
        cloud.transform.localScale += Vector3.right * cloudSize;

        //cloud.GetComponent<Rigidbody2D>().velocity = Vector2.left * cloudSpeed;
        cloud.tag = "Cloud";
        
    }
}
