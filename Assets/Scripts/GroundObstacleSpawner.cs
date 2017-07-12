using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacleSpawner : MonoBehaviour {

    public GameObject groundObstaclePrefab;

    private GameObject obstacleParent;

    private void OnDrawGizmos() {
        Gizmos.color = Color.red;
        Gizmos.DrawCube(transform.position, transform.localScale);
    }

    private void Start() {
        obstacleParent = GameObject.Find("Obstacles");
        if (obstacleParent == null) {
            obstacleParent = new GameObject("Obstacles");
        }
    }
    
    public void SpawnGroundObstacle(float obstacleSpeed) {
        GameObject groundObstacle = Instantiate(groundObstaclePrefab, transform.position, Quaternion.identity);
        groundObstacle.transform.parent = obstacleParent.transform;

        groundObstacle.GetComponent<Rigidbody2D>().velocity = Vector2.left * obstacleSpeed;
        groundObstacle.tag = "Obstacle";
    }

}
