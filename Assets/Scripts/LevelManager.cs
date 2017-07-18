using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

    public GameObject restartButton;

    private void OnEnable() {
        LoseCollider.OnFall += Lose;
    }

    private void OnDisable() {
        LoseCollider.OnFall -= Lose;
    }

    public void Start() {
        restartButton.SetActive(false);
    }

    public void Lose() {
        ShowLoseScreen();
        Time.timeScale = 0;
    }

    void ShowLoseScreen() {
        restartButton.SetActive(true);
    }

    public void RestartScene() {
        restartButton.SetActive(false);
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        Time.timeScale = 1;
    }

    public void LoadLevel(string level) {
        SceneManager.LoadScene(level);
    }
}
