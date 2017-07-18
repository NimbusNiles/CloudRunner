using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public GameObject restartButton;
    
    public void Start() {
        restartButton.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        OnFall();
    }

    void OnFall() {
        restartButton.SetActive(true);
        Time.timeScale = 0;
    }
}
