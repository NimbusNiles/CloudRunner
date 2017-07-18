using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundObstacle : MonoBehaviour {

    private LevelManager levelManager;

    private void Start() {
        levelManager = FindObjectOfType<LevelManager>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if(collision.tag == "Player") {
            Debug.Log("Player hit by obstacle");
        }
    }
}
