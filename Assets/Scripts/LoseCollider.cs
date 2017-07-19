using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoseCollider : MonoBehaviour {

    public GameObject LoseScreen;
    
    public void Start() {
        LoseScreen.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        OnFall();
    }

    void OnFall() {
        LoseScreen.SetActive(true);
        Time.timeScale = 0;
    }
}
