using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GoldManager : MonoBehaviour {

    public int thisRunGold = 0;
    public TextMeshProUGUI goldDisplay;

    private void OnEnable() {
        GoldCoin.OnGoldPickup += AddGold;
    }

    private void OnDisable() {
        GoldCoin.OnGoldPickup -= AddGold;
    }

    void AddGold(int amount) {
        thisRunGold += amount;
        UpdateGoldDisplay();
    }

    void UpdateGoldDisplay() {
        goldDisplay.text = thisRunGold.ToString();
    }
}
