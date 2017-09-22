using UnityEngine;

[System.Serializable]
public class ColorToPrefab
{
	public Color color;
	public GameObject prefab;
}

public class MapGenerator : MonoBehaviour {

	public GenerateLevel lm;
	public Texture2D map;

	public ColorToPrefab[] colorMappings;

	// Use this for initialization
	void Start () {
		lm = GameObject.FindGameObjectWithTag ("LM").GetComponent<GenerateLevel> ();
		map = lm.mapSelected;
		Generatelevel ();
	}

	void Generatelevel () {
		for (int x = 0; x < map.width; x++) {
			for (int y = 0; y < map.height; y++) {
				GenerateTile (x, y);		
			}
		}
	}

	void GenerateTile (int x, int y) {

		Color pixelColor = map.GetPixel(x, y);

		if (pixelColor.a == 0) {
			return;
		}

		foreach (var colorMapping in colorMappings) {

			if (colorMapping.color.Equals(pixelColor)) {

				Vector2 position = new Vector2 (x, y);
				Instantiate (colorMapping.prefab, position, Quaternion.identity, transform);
			}
		}
	}
}
