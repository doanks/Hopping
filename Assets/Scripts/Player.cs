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
	bool gameover;
	bool finish;
	bool jump;

	float gravityDefault;
	bool gravityChange;

	CameraFollow cam;
	GameManager gm;

	// Use this for initialization
	void Start () {

		gm	= FindObjectOfType<GameManager> ();

		cam = FindObjectOfType<CameraFollow> ();

		gravityDefault = rb.gravityScale;

		if (transform.position.x > 0) {
			cam.facingRight = false;
			myParent.localScale = new Vector2 (myParent.localScale.x * -1, myParent.localScale.y);
			transform.parent = null;
		} else {
			cam.facingRight = true;

		}
		//cam.facingRight = Mathf.Sign(transform.localScale.x) == 1 ? true : false;
		cam.target = gameObject.transform;
	}

	void Update () {

		if (firstTap && !gameover) {
			if(cam.facingRight)
				transform.Translate (Vector2.right * speed * Time.deltaTime);
			else
				transform.Translate (-Vector2.right * speed * Time.deltaTime);
		}

		bool grounded = Physics2D.Linecast(transform.position, groundPos.position, 1 << LayerMask.NameToLayer("Ground"));
		anim.SetBool ("grounded", grounded);

		//if (Input.GetKeyDown (KeyCode.Space) && grounded && !gameover)
		if (Input.GetMouseButtonDown(0) && grounded && !gameover)
			jump = true;

		if (transform.position.y < 0 && !gameover && !finish) {

			gameover = true;
			cam.finish = true;

			anim.enabled = false;
			rb.bodyType = RigidbodyType2D.Static;

			gm.GameFail ();
		}
	}
	
	// Update is called once per frame
	void FixedUpdate () {

		if (jump) {
			jump = false;
			if (!firstTap) {
				firstTap = true;
				rb.bodyType = RigidbodyType2D.Dynamic;
				gm.GameStart ();
			} else {
				rb.velocity = new Vector2 (rb.velocity.x, jumpPower);
				FindObjectOfType<SoundManager> ().Play ("Jump");
			}
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		
		if (other.tag == "Finish") {
			finish = true;
			cam.finish = true;
			gm.GameFinish ();
		}

		if (other.tag == "Wall") {
			
			float flipX = transform.localScale.x * -1f;
			transform.localScale = new Vector2 (flipX, transform.localScale.y);
			cam.facingRight = !cam.facingRight;
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

		if (other.collider.tag == "Fail" && !finish) {

			FindObjectOfType<SoundManager> ().Play ("Fail");

			gameover = true;
			cam.finish = true;

			anim.enabled = false;
			rb.bodyType = RigidbodyType2D.Static;

			gm.GameFail ();
		}

		if (other.collider.tag == "Perr") {
			gravityChange = true;
			rb.gravityScale = 6.5f;
			rb.velocity = new Vector2 (rb.velocity.x, 28);
		}
	}
}
