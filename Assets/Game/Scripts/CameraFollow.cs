using UnityEngine;

public class CameraFollow : MonoBehaviour {

	public GenerateLevel gl;
	public Player player;
	public Texture2D map;
	public float smooth;
	public float camLimitDistance;

	float xPos, yPos;
	float offsetX;

	public bool finish;

	bool firstPos;

	Vector3 velocity = Vector3.zero;

	void Start () {

		gl = FindObjectOfType<GenerateLevel>();
		player = FindObjectOfType<Player> ();
		map = gl.mapSelected;
	}
		
	void LateUpdate () {

		if (player == null || player.gameover)
			return;

		yPos = player.transform.position.y + .5f;
		offsetX = Mathf.Sign (player.transform.localScale.x) * 4f;

		if (player.transform.position.x + offsetX < camLimitDistance) {
			xPos = camLimitDistance;
		}
		else if (player.transform.position.x + offsetX > map.width - camLimitDistance - 1f) {
			xPos = map.width - camLimitDistance - 1f;
		} 
		else {
			xPos = player.transform.position.x + offsetX;
		}

		Vector3 camPos = new Vector3 (xPos, yPos, transform.position.z);

		if (!firstPos) {
			firstPos = true;
			transform.position = camPos;
		} else
			//transform.position = Vector3.SmoothDamp (transform.position, camPos, ref velocity, smooth);
			transform.position = Vector3.Lerp (transform.position, camPos, smooth);
	}
}