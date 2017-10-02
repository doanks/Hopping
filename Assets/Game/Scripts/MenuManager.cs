using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MenuManager : MonoBehaviour {

	public Text leveltext;
	//public Text textCount;

	public int levelChoice;
	int levelCount;

	public int[] stagePrefs;

	public GameObject levelPack, stages;

	int stageId;

	public GenerateLevel gm;

	void Start () {
		//PlayerPrefs.DeleteAll ();
		GoogleAds.instance.RequestBanner();
		FindObjectOfType<SoundManager> ().Stop ("BGM Gameplay");
		FindObjectOfType<SoundManager> ().Play ("BGM Menu");

		while (gm == null)
			gm = GenerateLevel.instance;

		gm.stageCount = stagePrefs.Length;

		for (int i = 0; i < stagePrefs.Length; i++) {
			stagePrefs[i] = PlayerPrefs.GetInt ("unlock_count_stage" + i);
		}
	}

	public void ButtonNext () {

		if (levelChoice >= levelCount)
			return;

		levelChoice++;
		leveltext.text = (levelChoice + 1).ToString();
		//textCount.text = (levelChoice + 1) + " / " + gm.stages [stageId].maps.Length;
		gm.SetMap (stageId, levelChoice);
	}

	public void ButtonPrev () {

		if (levelChoice <= 0)
			return;
		
		levelChoice--;
		leveltext.text = (levelChoice + 1).ToString();
		//textCount.text = (levelChoice + 1) + " / " + gm.stages [stageId].maps.Length;
		gm.SetMap (stageId, levelChoice);
	}

	public void ButtonStart () {
		GoogleAds.instance.bannerView.Destroy ();
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
		//textCount.text = (levelCount + 1) + " / " + gm.stages [id].maps.Length;
		gm.SetMap (id, levelChoice);

		stages.SetActive (false);
		levelPack.SetActive (true);
	}
}
