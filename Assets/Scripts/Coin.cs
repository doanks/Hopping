using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {

	public float smooth;
	bool getCoin;

	public GameObject coinLerp;

	public Animator anim;

	void Start () {

		coinLerp = GameObject.FindGameObjectWithTag ("CoinLerp");
	}

	void Update () {

		if (getCoin) {
			transform.position = Vector2.Lerp (transform.position, coinLerp.transform.position, smooth);
		}
	}

	void OnTriggerEnter2D (Collider2D other) {
		if (other.tag == "Player") {
			getCoin = true;
			anim.SetTrigger ("collect");
			Destroy(gameObject, 1f);
		}
	}
}
