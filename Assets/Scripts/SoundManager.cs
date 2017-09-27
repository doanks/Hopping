using UnityEngine.Audio;
using System;
using UnityEngine;

[System.Serializable]
public class Sound {

	public string name;
	public AudioClip clip;

	[Range(0f,1f)]
	public float volume;

	public bool loop;
	public bool bgm;

	[HideInInspector]
	public AudioSource source;
}

public class SoundManager : MonoBehaviour {

	public static SoundManager instance;

	public Sound[] sounds;

	void Awake () {

		if (instance == null)
			instance = this;
		else {
			Destroy (gameObject);
			return;
		}

		DontDestroyOnLoad (gameObject);

		foreach (Sound s in sounds) {
			s.source = gameObject.AddComponent<AudioSource>();
			s.source.clip = s.clip; 
			s.source.volume = s.volume;
			s.source.loop = s.loop;
		}
	}

	void Start () {
		Play ("BGM Menu");
	}

	public void Play (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null)
			return;

		if (s.bgm && s.source.isPlaying) {
			return;
		}

		s.source.Play ();
	}

	public void Stop (string name) {
		Sound s = Array.Find (sounds, sound => sound.name == name);
		if (s == null)
			return;
		s.source.Stop ();
	}

	public void SetVolume (float volume) {
		foreach (Sound s in sounds) {
			s.source.volume = volume * s.volume;
		}
	}
}
