﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DistanceManager : MonoBehaviour {

    public Text distanceText;
    public GameManager gameManager;

    private float distanceTravelled = 0;

    // Update is called once per frame
    void Update() {
        distanceTravelled += Time.deltaTime * gameManager.moveSpeed;
        UpdateDistanceDisplay();
    }

    void UpdateDistanceDisplay() {
        int distanceToDisplay = Mathf.RoundToInt(distanceTravelled);
        distanceText.text = distanceToDisplay.ToString() + " m";
    }
}