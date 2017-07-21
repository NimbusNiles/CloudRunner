﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {

    public float CurrentSpeed { get; set; }

    public float startSpeed;
    public List<float> speedRanges;
    public List<float> accelerationRanges;
    public GameObject cloudContainer;
    public GameObject goldContainer;

    private float acceleration;

    private void Start() {
        CurrentSpeed = startSpeed;
    }

    public void Update() {
        int speedRange = GetCurrentSpeedRange(speedRanges, CurrentSpeed);
        acceleration = accelerationRanges[speedRange];

        CurrentSpeed += acceleration * Time.deltaTime;
        Debug.Log(CurrentSpeed);

        cloudContainer.GetComponent<Rigidbody2D>().velocity = Vector2.left * CurrentSpeed;
        goldContainer.GetComponent<Rigidbody2D>().velocity = Vector2.left * CurrentSpeed;

    }

    public static int GetCurrentSpeedRange(List<float> speedRanges, float currentSpeed) {
        for(int ii = 0; ii < speedRanges.Count; ii++) {
            if (currentSpeed < speedRanges[ii]) {
                return ii-1;
            }
        }
        return speedRanges.Count;
    }


}
