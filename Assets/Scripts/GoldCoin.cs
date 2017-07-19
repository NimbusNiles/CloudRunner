using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoldCoin : MonoBehaviour {

    public int coinValue = 1;

    public static event Action<int> OnGoldPickup;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            OnGoldPickup(coinValue);
            Destroy(gameObject);
        }
    }
    
}
