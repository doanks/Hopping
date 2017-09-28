using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TransformAnimation : MonoBehaviour {

	public float speed;
	public float distance;
	
	// Update is called once per frame
	void Update () {

		transform.Translate (-Vector2.right * speed * Time.deltaTime);
	}
}
