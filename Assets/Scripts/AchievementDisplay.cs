using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AchievementDisplay : MonoBehaviour {
    
    public string achievementKey;

    public Sprite lockedSprite, unlockedSprite;
    public Slider slider;
    public TextMeshProUGUI achievementAmount;

	// Use this for initialization
	void Start () {
        if (achievementKey == null) {
            Debug.LogWarning("No achievemen key found for: " + gameObject);
        }
        
        if (achievementAmount != null) {
            UpdateAmountDisplay();
        }

	}

    void UpdateAmountDisplay() {
        achievementAmount.text = PlayerPrefs.GetInt(achievementKey).ToString();
    }
	
}
