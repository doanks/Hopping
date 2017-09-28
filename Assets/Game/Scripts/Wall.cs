using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wall : MonoBehaviour {

	public Collider2D coll;

	bool a;

	void Update () {

		if (a)
			return;
		else {
			if (Input.GetMouseButtonDown (0)) {
				a = true;
				Invoke ("Activate", 2f);
			}
		}

		if (Input.GetMouseButtonDown (0) && !a) {
			a = true;
			Invoke ("Activate", 2f);
		}
	}

	void Activate () {
		coll.enabled = true;
	}
}
