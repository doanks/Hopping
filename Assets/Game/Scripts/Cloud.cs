using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cloud : MonoBehaviour {

	public float speed;
	public float distance;
	
	// Update is called once per frame
	void Update () {

		if (transform.position.x < -distance) {
			transform.position = new Vector2 (distance, transform.position.y);
		}

		transform.Translate (-Vector2.right * speed * Time.deltaTime);
	}
}
