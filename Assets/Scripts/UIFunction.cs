using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour {

	bool mute;

	public void ChangeScene (string scenename) {
		SceneManager.LoadScene (scenename);
	}

	void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Menu") {
			Application.Quit ();
		}
	}

	public void Exit () {
		Application.Quit ();
	}
}