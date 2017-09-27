using UnityEngine;
using UnityEngine.SceneManagement;

public class UIFunction : MonoBehaviour {

	bool mute;

	public void ChangeScene (string scenename) {
		SceneManager.LoadScene (scenename);
	}

	public void Update () {

		if (Input.GetKeyDown(KeyCode.Escape) && SceneManager.GetActiveScene().name == "Menu") {
			Application.Quit ();
		}
	}

	public void ButtonAudio () {
		mute = !mute;
		if (mute) 
			FindObjectOfType<SoundManager> ().SetVolume (0f);
		else
			FindObjectOfType<SoundManager> ().SetVolume (1f);
	}

	public void Exit () {
		Application.Quit ();
	}
}