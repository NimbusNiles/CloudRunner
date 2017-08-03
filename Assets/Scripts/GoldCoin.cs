using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GoldCoin : MonoBehaviour {

    public int coinValue = 1;

    public static event Action<int> OnGoldPickup;
   
    private float spinDelta = 2f;
    private float spinDirection = -1;
    private Vector3 scaleVector = Vector3.one;
    private Vector3 initialScale;

    private void Start() {
        initialScale = transform.localScale;
    }

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
        } else if (scaleVector.x <= 0.05) {
            spinDirection = 1;
        }

        transform.localScale = new Vector3(scaleVector.x * initialScale.x, initialScale.y,initialScale.z);
    }

}
