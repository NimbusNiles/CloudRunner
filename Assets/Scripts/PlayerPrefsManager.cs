using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsManager : MonoBehaviour {

    const string MASTER_VOLUME_KEY = "master_volume";
    const string SKIN_KEY = "skin_unlocked_";
    const string GOLD_KEY = "gold";

    public static void SetMasterVolume(float volume) {
        if (volume >= 0f && volume <= 1f) {
            PlayerPrefs.SetFloat(MASTER_VOLUME_KEY, volume);
        } else {
            Debug.LogError("Master volume out of range");
        }
    }

    public static float GetMasterVolume() {
        return PlayerPrefs.GetFloat(MASTER_VOLUME_KEY);
    }

    public static void UnlockSkin(int skinID) {
        PlayerPrefs.SetInt(SKIN_KEY + skinID.ToString(), 1);
    }

    public static bool IsSkinUnlocked(int skinID) {
        if (PlayerPrefs.GetInt(SKIN_KEY + skinID.ToString()) == 1) {
            return true;
        } else {
            return false;
        }
    }

    public static int GetGoldAmount() {
        return PlayerPrefs.GetInt(GOLD_KEY);
    }

    public static void SetGoldAmount(int amount) {
        PlayerPrefs.SetInt(GOLD_KEY, amount);
    }
    
}
