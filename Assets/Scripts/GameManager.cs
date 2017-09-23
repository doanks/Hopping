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

		int stage = gl.stageId;
		int map = gl.mapId;

		if (gl.mapId < gl.stages[stage].maps.Length - 1) {
			map++;
			gl.SetMap (stage, map);

			if (stage == 0) {
				int a = PlayerPrefs.GetInt ("stage1_unlock_count");
				if (a < map)
					PlayerPrefs.SetInt ("stage1_unlock_count", map);
			} else if (stage == 1) {
				int a = PlayerPrefs.GetInt ("stage2_unlock_count");
				if (a < map)
					PlayerPrefs.SetInt ("stage2_unlock_count", map);
			} else {
				int a = PlayerPrefs.GetInt ("stage3_unlock_count");
				if (a < map)
					PlayerPrefs.SetInt ("stage3_unlock_count", map);
			}
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
