using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour {

	public void ChangeScene (string scenename) {
		SceneManager.LoadScene (scenename);
	}

	public void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Menu") {
			Application.Quit ();
		}
	}
}