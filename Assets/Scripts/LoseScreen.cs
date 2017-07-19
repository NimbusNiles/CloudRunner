using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class LoseScreen : MonoBehaviour {

    public TextMeshProUGUI goldText;
    public GoldManager goldManager;

    private void OnEnable() {
        AwardGold();
        ShowGold();
    }

    void AwardGold() {
        int goldAmount = PlayerPrefsManager.GetGoldAmount();
        goldAmount += goldManager.thisRunGold;
        PlayerPrefsManager.SetGoldAmount(goldAmount);
    }

    void ShowGold() {
        goldText.text = goldManager.thisRunGold.ToString();
    }

}
