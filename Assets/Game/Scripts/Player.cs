using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

	public float speed;

	public Rigidbody2D rb;
	public Animator anim;
	public Transform groundPos;
	public float jumpPower;

	public Transform myParent;

	bool firstTap;
	public bool gameover;
	bool Jump;

	float gravityDefault;
	bool gravityChange;

	GameManager gm;

	// Use this for initialization
	void Start () {

		gm	= FindObjectOfType<GameManager> ();

		gravityDefault = rb.gravityScale;

		if (transform.position.x > 0) {
			myParent.localScale = new Vector2 (myParent.localScale.x * -1, myParent.localScale.y);
		} 

		transform.parent = null;
	}

	void Update () {

		if (gameover)
			return;

		bool grounded = Physics2D.Linecast(transform.position, groundPos.position, 1 << LayerMask.NameToLayer("Ground"));
		anim.SetBool ("grounded", grounded);

		if (Input.GetMouseButtonDown(0) && grounded){
			Jump = true;
		}
	}

	void FixedUpdate () {

		if (gameover)
			return;

		if (Jump) {
			Jump = false;
			if (firstTap) {
				rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
				FindObjectOfType<SoundManager> ().Play ("Jump");
			} else {
				firstTap = true;
				rb.bodyType = RigidbodyType2D.Dynamic;
				gm.GameStart ();
				return;
			}
		}

		if (!firstTap)
			return;

		rb.velocity = new Vector2 (speed * Mathf.Sign(transform.localScale.x), rb.velocity.y);
			
		if (transform.position.y < 0) {

			gameover = true;

			anim.enabled = false;
			rb.bodyType = RigidbodyType2D.Static;

			gm.GameFail ();
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.tag == "Finish") {
			gameover = true;
			gm.GameFinish ();
		}

		if (other.tag == "Wall") {
			
			float flipX = transform.localScale.x * -1f;
			transform.localScale = new Vector2 (flipX, transform.localScale.y);
		}

		if (other.tag == "Fast") {
			speed = 10;
		}

		if (other.tag == "Slow") {
			speed = 5;
		}
	}

	void OnCollisionEnter2D (Collision2D other) {

		if (gravityChange) {
			gravityChange = false;
			rb.gravityScale = gravityDefault;
		}

		if (other.collider.tag == "Fail") {

			FindObjectOfType<SoundManager> ().Play ("Fail");

			gameover = true;
			anim.enabled = false;
			rb.bodyType = RigidbodyType2D.Static;

			gm.GameFail ();
		}

		if (other.collider.tag == "Perr") {

			FindObjectOfType<SoundManager> ().Play ("Long Jump");
			
			gravityChange = true;
			rb.gravityScale = 6.5f;
			rb.velocity = new Vector2 (rb.velocity.x, 28);
		}
	}
}
