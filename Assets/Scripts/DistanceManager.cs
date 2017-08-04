using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using System;

public class DistanceManager : MonoBehaviour {

    public TextMeshProUGUI distanceDisplay;
    public GameManager gameManager;

    public static Action<int> OnReachingMeters;

    private float distanceTravelled = 0;

    // Update is called once per frame
    void Update() {
        distanceTravelled += Time.deltaTime * gameManager.moveSpeed;
        UpdateDistanceDisplay();

        if (distanceTravelled >= 100) {
            if (OnReachingMeters != null) {
                OnReachingMeters(100);
            }
            return;
        }

        if (distanceTravelled >= 0 && distanceTravelled < 100) {
            if (OnReachingMeters != null) {
                OnReachingMeters(0);
            }
            return;
        }
    }

    void UpdateDistanceDisplay() {
        int distanceToDisplay = Mathf.RoundToInt(distanceTravelled);
        distanceDisplay.text = distanceToDisplay.ToString() + " m";
    }
}
