using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float jumpForce;
    public bool canJump = true;
    public float inputTimeToMaxJump;

    private bool inputPressed = false;
    private float inputPressedForSeconds = 0;

    private SpriteRenderer spriteRenderer;
    private Animator myAnimator;

	// Use this for initialization
	void Start () {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown(KeyCode.Space)) {
            inputPressed = true;
            inputPressedForSeconds = 0f;
            spriteRenderer.color = Color.red;
        }

        if (inputPressed) {
            inputPressedForSeconds += Time.deltaTime;
        }

        if (Input.GetKeyUp(KeyCode.Space)) {
            inputPressed = false;
            spriteRenderer.color = Color.white;

            if (canJump) {
                float jumpPercent = Mathf.Clamp(inputPressedForSeconds / inputTimeToMaxJump, 0.75f, 1);
                Jump(jumpPercent);
                canJump = false;
            }
        }


	}

    void Jump(float jumpPercent) {
        GetComponent<Rigidbody2D>().AddForce(Vector2.up * jumpPercent * jumpForce);
        myAnimator.Play("Jumping");
    }

    private void OnCollisionEnter2D(Collision2D collision) {
        canJump = true;
        myAnimator.Play("Idle");
    }

    private void OnCollisionExit2D(Collision2D collision) {
        canJump = false;
    }


}
