using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text leveltext;

	public int levelChoice;
	int levelCount;
	public int prefs1, prefs2, prefs3;

	public GameObject levelPack, stages;

	int stageId;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		prefs1 = PlayerPrefs.GetInt ("stage1_unlock_count");
		prefs2 = PlayerPrefs.GetInt ("stage2_unlock_count");
		prefs3 = PlayerPrefs.GetInt ("stage3_unlock_count");
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
		SceneManager.LoadScene ("Gameplay");
	}

	public void ButtonStages (int id) {

		stageId = id;
		
		if (id == 0) levelCount = prefs1;
		else if (id == 1) levelCount = prefs2;
		else levelCount = prefs3;

		levelChoice = levelCount;
		leveltext.text = (levelCount+1).ToString ();
		GenerateLevel.instance.SetMap (id, levelChoice);

		stages.SetActive (false);
		levelPack.SetActive (true);
	}
}
