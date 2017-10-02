using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GenerateLevel gl;
	public Player target;

	public Texture2D map;
	public float smooth;
	public float camLimitDistance;

	float xPos, yPos;
	float offsetX;

	bool firstPos;

	public float targetPos;

	void Start () {

		gl = FindObjectOfType<GenerateLevel>();
		target = FindObjectOfType<Player> ();
		map = gl.mapSelected;
		//yPos = target.transform.position.y + 1f;
	}
		
	void LateUpdate () {

		if (target == null) {
			target = FindObjectOfType<Player> ();
			return;
		}

		if (map == null) {
			gl = FindObjectOfType<GenerateLevel>();
			map = gl.mapSelected;
			//yPos = target.transform.position.y + 1f;
			return;
		}

		yPos = target.transform.position.y + 1f;
		//yPos = Mathf.Lerp (transform.position.y, target.transform.position.y + 1f, smooth);

		offsetX = 4f * Mathf.Sign (target.transform.localScale.x);

		if (target.transform.position.x + offsetX < camLimitDistance) {
			xPos = camLimitDistance;
		}
		else if (target.transform.position.x + offsetX > map.width - camLimitDistance - 1f) {
			xPos = map.width - camLimitDistance - 1f;
		} 
		else {
			xPos = target.transform.position.x + offsetX;
		}

		Vector3 camPos = new Vector3 (xPos, yPos, transform.position.z);
		transform.position = camPos;
	}
}













//		if (!firstPos) {
//			firstPos = true;
//			transform.position = camPos;
//		} else
//			transform.position = Vector3.SmoothDamp (transform.position, camPos, ref velocity, smooth);
//transform.position = Vector3.Lerp (transform.position, camPos, smooth);