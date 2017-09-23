using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	// Use this for initialization
	void Start () {
		if (transform.position.x > 0) {
			transform.localScale = new Vector2 (transform.localScale.x * -1, transform.localScale.y);
		}
	}
}
