using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartCloud : MonoBehaviour {

    public float startCloudSpeed;

    void Start () {
        GetComponent<Rigidbody2D>().velocity = Vector2.left * startCloudSpeed;
	}
}
