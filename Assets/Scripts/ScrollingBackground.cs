using UnityEngine;

public class ScrollingBackground : MonoBehaviour {

	public float backgroundSize;
	public float viewZone;
	public float paralaxSpeed;
	public float smoothVerticalLerp;
	 
	Transform cameraTransform;
	Transform[] layers;
	int leftIndex;
	int rightIndex;
	float lastCameraX;


	void Start () {
		
		cameraTransform = Camera.main.transform;
		lastCameraX = cameraTransform.position.x;

		layers = new Transform[transform.childCount];
		for (int i = 0; i < transform.childCount; i++) {
			layers [i] = transform.GetChild (i);
		}

		leftIndex = 0;
		rightIndex = layers.Length - 1;
	}

	void ScrollingRight () {

		float posX = layers [rightIndex].transform.position.x + backgroundSize;
		layers [leftIndex].transform.position = new Vector3(posX, layers[leftIndex].transform.position.y, 0);
		rightIndex = leftIndex;
		leftIndex++;
		if (leftIndex == layers.Length)
			leftIndex = 0;
	}

	void ScrollingLeft () {

		float posX = layers [leftIndex].transform.position.x - backgroundSize;
		layers [rightIndex].transform.position = new Vector3(posX, layers[rightIndex].transform.position.y, 0);
		leftIndex = rightIndex;
		rightIndex--;
		if (rightIndex < 0)
			rightIndex = layers.Length - 1;
	}

	void Update () {

		float deltaX = cameraTransform.position.x - lastCameraX;
		float posX = transform.position.x + (deltaX * paralaxSpeed);
		float lerpY = Mathf.Lerp (transform.position.y, cameraTransform.position.y, smoothVerticalLerp); 
		transform.position = new Vector3 (posX, lerpY, transform.position.z);
		//transform.position += Vector3.right * (deltaX * paralaxSpeed);
		lastCameraX = cameraTransform.position.x;

		if (cameraTransform.position.x < (layers [leftIndex].transform.position.x + viewZone)) {
			ScrollingLeft ();
		}
		if (cameraTransform.position.x > (layers [rightIndex].transform.position.x - viewZone)) {
			ScrollingRight ();
		}
	}
}
