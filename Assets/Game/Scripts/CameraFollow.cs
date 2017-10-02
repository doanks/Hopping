using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GenerateLevel gl;
	public Transform target;
	public Texture2D map;
	public float smooth;
	public float camLimitDistance;

	float xPos, yPos;
	float offsetX;

	public bool facingRight;
	public bool finish;

	bool firstPos;

	//Vector3 velocity = Vector3.zero;

	void Start () {

		gl = FindObjectOfType<GenerateLevel>();
		map = gl.mapSelected;
	}
		
	void LateUpdate () {

		if (finish || target == null)
			return;

		//yPos = target.transform.position.y + 1f;
		yPos = Mathf.Lerp(transform.position.y,  target.transform.position.y + .5f, smooth);

		if (facingRight)
			offsetX = 4f;
		else
			offsetX = -4f;

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

//		if (!firstPos) {
//			firstPos = true;
//			transform.position = camPos;
//		} else
//			transform.position = Vector3.SmoothDamp (transform.position, camPos, ref velocity, smooth);
			//transform.position = Vector3.Lerp (transform.position, camPos, smooth);
	}

//	Vector3 offset;
//
////	public void GetOffset () {
////		offset = transform.position - target.transform.position;
////	}
//
//	void LateUpdate () {
//
//		if (target == null)
//			return;
//		
//		//transform.position = target.transform.position + offset;
//
//		Vector3 delta = target.transform.position - Vector3.zero;
//		Vector3 destination = transform.position + delta;
//
//		transform.position = destination;
//
//	}
}