using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text leveltext;

	public int levelChoice;
	public int prefs1;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		prefs1 = PlayerPrefs.GetInt ("stage1_unlock_count");
		levelChoice = prefs1;
		leveltext.text = (prefs1+1).ToString ();
		GenerateLevel.instance.SetMap (levelChoice);
	}

	public void ButtonNext () {
		if (levelChoice < prefs1) {
			levelChoice++;
			leveltext.text = (levelChoice + 1).ToString();
			GenerateLevel.instance.SetMap (levelChoice);
		}
	}

	public void ButtonPrev () {
		if (levelChoice > 0 ) {
			levelChoice--;
			leveltext.text = (levelChoice + 1).ToString();
			GenerateLevel.instance.SetMap (levelChoice);
		}
	}

	public void ButtonStart () {
		SceneManager.LoadScene ("Gameplay");
	}
}
