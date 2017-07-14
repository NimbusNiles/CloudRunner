using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedManager : MonoBehaviour {

    public float CurrentSpeed { get; set; }

    public float startSpeed;
    public List<float> speedRanges;
    public List<float> accelerationRanges;
    public GameObject cloudContainer;

    private float acceleration;

    private void Start() {
        CurrentSpeed = startSpeed;
    }

    public void Update() {
        int speedRange = GetCurrentSpeedRange();
        acceleration = accelerationRanges[speedRange];

        CurrentSpeed += acceleration * Time.deltaTime;

        cloudContainer.GetComponent<Rigidbody2D>().velocity = Vector2.left * CurrentSpeed;
    }

    int GetCurrentSpeedRange() {
        for(int ii = 0; ii < speedRanges.Count; ii++) {
            if (CurrentSpeed < speedRanges[ii]) {
                return ii - 1;
            }
        }
        return speedRanges.Count;
    }


}
