using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateLevel : MonoBehaviour {

	public static GenerateLevel instance;

	public Texture2D mapSelected;
	public Texture2D[] maps;

	public int id;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	void Start () {
		//id = PlayerPrefs.GetInt ("stage1_unlock_count");
		//SetMap (id);
	}

	public void SetMap (int id) {
		mapSelected = maps [id];
		this.id = id;
	}
}