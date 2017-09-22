using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GenerateLevel lm;
	public Transform target;
	public Texture2D map;
	public float smooth;
	public float camLimitDistance;

	float xPos, yPos;
	float offsetX;

	public bool facingRight;
	public bool finish;

	bool firstPos;

	void Start () {
		lm = GameObject.FindGameObjectWithTag ("LM").GetComponent<GenerateLevel> ();
		map = lm.mapSelected;
	}
		
	// Update is called once per frame
	void LateUpdate () {

		if (!finish) {
			yPos = target.transform.position.y + 1f;

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
		}
		Vector3 camPos = new Vector3 (xPos, yPos, transform.position.z);

		if (!firstPos) {
			firstPos = true;
			transform.position = camPos;
		}
		else
			transform.position = Vector3.Lerp (transform.position, camPos, smooth);
		
	}
}