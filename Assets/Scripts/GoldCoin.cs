using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoldCoin : MonoBehaviour {

    public int coinValue = 1;

    public static event Action<int> OnGoldPickup;
   
    private float spinTime = 1f;
    private float spinDelta = 2f;
    private float spinDirection = -1;
    private Vector3 scaleVector = Vector3.one;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.tag == "Player") {
            OnGoldPickup(coinValue);
            Destroy(gameObject);
        }
    }

    private void Update() {
        
        scaleVector.x = Mathf.Clamp(scaleVector.x + Time.deltaTime * spinDelta * spinDirection, 0f, 1f);

        if (scaleVector.x >= 1) {
            spinDirection = -1;
        }else if(scaleVector.x <= 0) {
            spinDirection = 1;
        }

        Debug.Log(scaleVector);

        transform.localScale = scaleVector;

    }

}
