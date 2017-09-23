using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public GameObject go, complete, fail;

	GenerateLevel gl;

	void Start () {
		gl = GameObject.FindGameObjectWithTag ("LM").GetComponent<GenerateLevel> ();
	}

	public void GameStart () {
		go.SetActive (false);
	}

	public void GameFail () {
		StartCoroutine (FailCoroutine ());
	}

	public void GameFinish () {
		
		complete.SetActive (true);

		if (gl.id < gl.maps.Length - 1) {
			gl.id++;
			gl.SetMap (gl.id);
			int a = PlayerPrefs.GetInt ("stage1_unlock_count");
			if (a < gl.id) PlayerPrefs.SetInt ("stage1_unlock_count", gl.id);
			Invoke ("Restart", 1f);
		}
		else Invoke ("GotoMenu", 1f);
	}

	void GotoMenu () {
		SceneManager.LoadScene ("LevelPack");
	}

	void Restart () {
		SceneManager.LoadScene (SceneManager.GetActiveScene().name);
	}

	IEnumerator FailCoroutine () {
		fail.SetActive (true);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
