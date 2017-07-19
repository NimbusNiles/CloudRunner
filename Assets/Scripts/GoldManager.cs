using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoldManager : MonoBehaviour {

    public int thisRunGold = 0;

    private void OnEnable() {
        GoldCoin.OnGoldPickup += AddGold;
    }

    private void OnDisable() {
        GoldCoin.OnGoldPickup -= AddGold;
    }

    void AddGold(int amount) {
        thisRunGold += amount;
    }
}
