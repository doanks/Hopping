using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text leveltext;

	public int levelChoice;
	int levelCount;

	public int[] stagePrefs;

	public GameObject levelPack, stages;

	int stageId;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		FindObjectOfType<SoundManager> ().Stop ("BGM Gameplay");
		FindObjectOfType<SoundManager> ().Play ("BGM Menu");
		GenerateLevel.instance.stageCount = stagePrefs.Length;
		for (int i = 0; i < stagePrefs.Length; i++) {
			stagePrefs[i] = PlayerPrefs.GetInt ("unlock_count_stage" + i);
		}
	}

	public void ButtonNext () {
		if (levelChoice < levelCount) {
			levelChoice++;
			leveltext.text = (levelChoice + 1).ToString();
			GenerateLevel.instance.SetMap (stageId, levelChoice);
		}
	}

	public void ButtonPrev () {
		if (levelChoice > 0 ) {
			levelChoice--;
			leveltext.text = (levelChoice + 1).ToString();
			GenerateLevel.instance.SetMap (stageId, levelChoice);
		}
	}

	public void ButtonStart () {
		FindObjectOfType<SoundManager> ().Stop ("BGM Menu");
		SceneManager.LoadScene ("Gameplay");
	}

	public void ButtonStages (int id) {

		stageId = id;

		for (int i = 0; i < stagePrefs.Length; i++) {
			if (id == i)
				levelCount = stagePrefs [i];
		}

		levelChoice = levelCount;
		leveltext.text = (levelCount+1).ToString ();
		GenerateLevel.instance.SetMap (id, levelChoice);

		stages.SetActive (false);
		levelPack.SetActive (true);
	}
}
