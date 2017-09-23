using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class MapStages {

	public Texture2D[] maps;

	public MapStages (Texture2D[] maps) {
		this.maps = maps;
	}
}

public class GenerateLevel : MonoBehaviour {

	public static GenerateLevel instance;

	public Texture2D mapSelected;
	public MapStages[] stages;

	public int stageId;
	public int mapId;

	void Awake () {
		if (instance == null) {
			instance = this;
		} else {
			Destroy (gameObject);
		}

		DontDestroyOnLoad (gameObject);
	}

	public void SetMap (int stageId, int mapId) {
		mapSelected = stages[stageId].maps[mapId];
		this.stageId = stageId;
		this.mapId = mapId;
	}
}