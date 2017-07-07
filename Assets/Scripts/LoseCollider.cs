using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class LoseCollider : MonoBehaviour {

    public static event Action OnFall;

    private void OnTriggerEnter2D(Collider2D collision) {
        OnFall();
    }
}
