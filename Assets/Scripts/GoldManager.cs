using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour {

    public int thisRunGold = 0;
    public TextMeshProUGUI goldDisplay;

    public Color[] goldColors;

    public static int CurrentGoldValue { get; set; }
    public static Color CurrentGoldColor { get; set; }

    private void OnEnable() {
        GoldCoin.OnGoldPickup += AddGold;
        DistanceManager.OnReachingMeters += SetGoldValue;
    }

    private void OnDisable() {
        GoldCoin.OnGoldPickup -= AddGold;
        DistanceManager.OnReachingMeters -= SetGoldValue;
    }

    void AddGold(int amount) {
        thisRunGold += amount;
        UpdateGoldDisplay();
    }

    void UpdateGoldDisplay() {
        goldDisplay.text = thisRunGold.ToString();
    }

    void SetGoldValue(int meters) {
        switch (meters) {
            case 0:
                CurrentGoldValue = 5;
                CurrentGoldColor = goldColors[0];
                break;
            case 100:
                CurrentGoldValue = 10;
                CurrentGoldColor = goldColors[1];
                break;
        }
    }
}
