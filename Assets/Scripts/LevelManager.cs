using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject loseScreen;

    private void OnEnable() {
        LoseCollider.OnFall += Lose;
    }

    private void OnDisable() {
        LoseCollider.OnFall -= Lose;
    }

    void Lose() {
        ShowLoseScreen();
        Time.timeScale = 0;
    }

    void ShowLoseScreen() {
        loseScreen.SetActive(true);
    }

    public void RestartScene() {
        loseScreen.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }
}
