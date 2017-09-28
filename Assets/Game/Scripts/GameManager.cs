using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public Text level;
	public Text scoreText;
	public GameObject go, complete, fail;

	public Animator bgAnim;

	public int totalCoin;
	public int currentCoin;

	GenerateLevel gl;

	public static int playCount;

	void Start () {
		
		gl = GameObject.FindGameObjectWithTag ("LM").GetComponent<GenerateLevel> ();

//		if(Mathf.Repeat(playCount,5) == 0) 
//			GoogleAds.instance.RequestInterstitial();

		playCount++;

		FindObjectOfType<SoundManager> ().Play ("BGM Gameplay");

		level.text = "Level  " + (gl.mapId + 1);

		totalCoin = 0;
		for (int i = 0; i < gl.mapId; i++) {
			totalCoin += PlayerPrefs.GetInt ("stage" + gl.stageId + "level" + i);
		}

	}

	void Update () {
		scoreText.text = (totalCoin + currentCoin).ToString ();;
	}

	public void GameStart () {
		go.SetActive (false);
	}

	public void GameFail () {

//		if(Mathf.Repeat(playCount,5) == 0) 
//			GoogleAds.instance.ShowInterstitial();
		
		StartCoroutine (FailCoroutine ());
	}

	public void GameFinish () {

//		if(Mathf.Repeat(playCount,5) == 0) 
//			GoogleAds.instance.ShowInterstitial();
		
		complete.SetActive (true);
		bgAnim.SetTrigger ("end");

		int stage = gl.stageId;
		int map = gl.mapId;

		int x = PlayerPrefs.GetInt ("stage" + stage + "level" + map);
		if (x < currentCoin) {
			PlayerPrefs.SetInt ("stage" + stage + "level" + map, currentCoin);
		}

		if (gl.mapId < gl.stages[stage].maps.Length - 1) {
			map++;
			gl.SetMap (stage, map);

			for (int i = 0; i < gl.stageCount; i++) {
				if (stage == i) {
					int a = PlayerPrefs.GetInt ("unlock_count_stage" + i);
					if (a < map)
						PlayerPrefs.SetInt ("unlock_count_stage" + i, map);
				}
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
		bgAnim.SetTrigger ("end");
		fail.SetActive (true);
		yield return new WaitForSeconds (1f);
		SceneManager.LoadScene (SceneManager.GetActiveScene ().name);
	}
}
