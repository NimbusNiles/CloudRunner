using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public bool canJump = true;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space) && canJump) {
            GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpForce);
            canJump = false;
        }
	}
    
    private void OnCollisionEnter2D(Collision2D collision) {
        canJump = true;
    }


}
